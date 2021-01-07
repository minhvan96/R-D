using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using IdentityModel;
using Novell.Directory.Ldap;

namespace IdentityServer.Investigate.LDAP
{
    public static class LdapAttributesExtensions
    {
        /// <summary>
        /// Create from an <see cref="Enum"/> the description array.
        /// </summary>
        /// <typeparam name="T">An enum type</typeparam>
        /// <returns>An Array of the descriptions (no duplicate)</returns>
        /// <exception cref="ArgumentException">T must be an enumerated type</exception>
        public static Array ToDescriptionArray<T>()
            where T : IConvertible //,struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            List<string> result = new List<string>();
            foreach (var e in Enum.GetValues(typeof(T)))
            {
                var fi = e.GetType().GetField(e.ToString());
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var description = attributes[0].Description;
                if (!result.Contains(description))
                {
                    result.Add(description);
                }
            }

            return result.ToArray();
        }

        public static string ToDescriptionString(this ActiveDirectoryLdapAttributes val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }

    public enum ActiveDirectoryLdapAttributes
    {
        [Description("displayName")]
        DisplayName,

        [Description("givenName")]
        FirstName,

        [Description("sn")] // Surname
        LastName,

        [Description("description")]
        Description,

        [Description("telephoneNumber")]
        TelephoneNumber,

        [Description("name")] // Also used as user name
        Name,

        [Description("whenCreated")]
        CreatedOn,

        [Description("whenChanged")]
        UpdatedOn,

        [Description("sAMAccountName")]
        UserName,

        [Description("mail")]
        EMail,

        [Description("memberOf")] // Groups attribute that can appears multiple time
        MemberOf
    }

    internal class Enum<T> where T : struct, IConvertible
    {
        /// <summary>
        /// Gets the descriptions attribute from an Enum (all of them at once).
        /// </summary>
        /// <exception cref="ArgumentException">T must be an enumerated type</exception>
        public static string[] Descriptions
        {
            get
            {
                if (!typeof(T).IsEnum)
                    throw new ArgumentException("T must be an enumerated type");

                List<string> result = new List<string>();
                foreach (var e in Enum.GetValues(typeof(T)))
                {
                    var fi = e.GetType().GetField(e.ToString());
                    var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    var description = attributes[0].Description;
                    if (!result.Contains(description))
                    {
                        result.Add(description);
                    }
                }

                return result.ToArray();
            }
        }
    }

    public class ActiveDirectoryAppUser : IAppUser
    {
        private string _subjectId = null;

        public string SubjectId
        {
            get => _subjectId ?? Username;
            set => _subjectId = value;
        }

        public string ProviderSubjectId { get; set; }
        public string ProviderName { get; set; }

        public string DisplayName { get; set; }
        public string Username { get; set; }

        public bool IsActive
        {
            get { return true; } // Always true for us, but we should look if the account have been locked out.
            set { }
        }

        public ICollection<Claim> Claims { get; set; }

        public string[] LdapAttributes => Enum<ActiveDirectoryLdapAttributes>.Descriptions;

        /// <summary>
        /// Fills the claims.
        /// </summary>
        /// <param name="user">The user.</param>
        private void FillClaims(LdapEntry user)
        {
            // Example in LDAP we have display name as displayName (normal field)
            //const string DisplayNameAttribute = "displayName";

            this.Claims = new List<Claim>
                {
                    GetClaimFromLdapAttributes(user, JwtClaimTypes.Name, ActiveDirectoryLdapAttributes.DisplayName),
                    GetClaimFromLdapAttributes(user, JwtClaimTypes.FamilyName, ActiveDirectoryLdapAttributes.LastName),
                    GetClaimFromLdapAttributes(user, JwtClaimTypes.GivenName, ActiveDirectoryLdapAttributes.FirstName),
                    GetClaimFromLdapAttributes(user, JwtClaimTypes.Email, ActiveDirectoryLdapAttributes.EMail),
                    GetClaimFromLdapAttributes(user, JwtClaimTypes.PhoneNumber, ActiveDirectoryLdapAttributes.TelephoneNumber),
                    GetClaimFromLdapAttributes(user, "createdOn", ActiveDirectoryLdapAttributes.CreatedOn),
                    GetClaimFromLdapAttributes(user, "updatedOn", ActiveDirectoryLdapAttributes.UpdatedOn),
                };

            // Add claims based on the user groups
            // add the groups as claims -- be careful if the number of groups is too large
            if (true)
            {
                try
                {
                    var userRoles = user.GetAttribute(ActiveDirectoryLdapAttributes.MemberOf.ToDescriptionString()).StringValues;
                    while (userRoles.MoveNext())
                    {
                        this.Claims.Add(new Claim(JwtClaimTypes.Role, userRoles.Current.ToString()));
                    }
                    //var roles = userRoles.Current (x => new Claim(JwtClaimTypes.Role, x.Value));
                    //id.AddClaims(roles);
                    //Claims = this.Claims.Concat(new List<Claim>()).ToList();
                }
                catch (Exception)
                {
                    // No roles exists it seems.
                }
            }
        }

        /// <summary>
        /// Fills the extra claims
        /// </summary>
        /// <param name="ldapEntry"></param>
        /// <param name="extrafields"></param>
        private void FillExtrafields(LdapEntry user, IEnumerable<string> extrafields)
        {
            if (extrafields == null) return;

            // with the AttributeSet we can check the check if the wanted fields exist
            var keyset = user.GetAttributeSet();
            foreach (var field in extrafields)
            {
                if (keyset.Keys.Contains(field))
                {
                    this.Claims.Add(new Claim(field, user.GetAttribute(field).StringValue));
                }
            }
        }

        /// <summary>
        /// Requesteds the LDAP attributes.
        /// </summary>
        /// <returns>Returns a special/requested ldap attribute.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string[] RequestedLdapAttributes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the claim from LDAP attributes.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="claim">The claim.</param>
        /// <param name="ldapAttribute">The LDAP attribute.</param>
        /// <returns>Returns the claim.</returns>
        internal Claim GetClaimFromLdapAttributes(LdapEntry user, string claim, ActiveDirectoryLdapAttributes ldapAttribute)
        {
            string value = string.Empty;
            try
            {
                return new Claim(claim, user.GetAttribute(ldapAttribute.ToDescriptionString()).StringValue);
            }
            catch (KeyNotFoundException)
            {
                // We could do logs about this. But basically the attribute is not found.
            }
            catch (Exception)
            {
                // Catch all to swallow the exception.
            }

            return new Claim(claim, value); // Return an empty claim
        }

        /// <summary>
        /// This will set the base details such as:
        /// - DisplayName (Can be null/non existent)
        /// - Username
        /// - ProviderName
        /// - SubjectId
        /// - ProviderSubjectId
        /// - Fill the claims
        /// </summary>
        /// <param name="ldapEntry">Ldap Entry</param>
        /// <param name="providerName">Specific provider such as Google, Facebook, etc.</param>
        public void SetBaseDetails(LdapEntry ldapEntry, string providerName, IEnumerable<string> extrafields = null)
        {
            DisplayName = "ldapEntry.GetNullableAttribute(ActiveDirectoryLdapAttributes.DisplayName.ToDescriptionString())?.StringValue;";
            Username = ldapEntry.GetAttribute(ActiveDirectoryLdapAttributes.UserName.ToDescriptionString()).StringValue;
            ProviderName = providerName;
            SubjectId = Username; // We could use the uidNumber instead in a sha algo.
            ProviderSubjectId = Username;
            FillClaims(ldapEntry);

            FillExtrafields(ldapEntry, extrafields);
        }
    }
}