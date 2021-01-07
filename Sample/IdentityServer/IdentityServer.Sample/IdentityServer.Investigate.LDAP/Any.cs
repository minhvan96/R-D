using Microsoft.Extensions.Logging;
using Novell.Directory.Ldap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace IdentityServer.Investigate.LDAP
{
    public enum UserStore
    {
        InMemory,
        Redis
    }

    public interface IAppUser
    {
        // Mandatory
        string SubjectId { get; set; }

        string Username { get; set; }
        string ProviderSubjectId { get; set; }
        string ProviderName { get; set; }
        bool IsActive { get; set; }
        string DisplayName { get; set; }

        ICollection<Claim> Claims { get; set; }

        /// <summary>
        /// Define the Ldap attributes that will be map on the user.
        /// </summary>
        string[] LdapAttributes { get; }

        /// <summary>
        /// This will set the base details such as:
        /// - DisplayName
        /// - Username
        /// - ProviderName
        /// - SubjectId
        /// - ProviderSubjectId
        /// - Fill the claims
        /// </summary>
        /// <param name="ldapEntry">Ldap Entry</param>
        /// <param name="providerName">Specific provider such as Google, Facebook, etc.</param>
        void SetBaseDetails(LdapEntry ldapEntry, string providerName, IEnumerable<string> extraFields = null);
    }

    public interface ILdapService<out TUser>
        where TUser : IAppUser, new()
    {
        /// <summary>
        /// Logins using the specified credentials.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>Returns the logged in user.</returns>
        TUser Login(string username, string password);

        /// <summary>
        /// Logins using the specified credentials.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="domain">The domain friendly name.</param>
        /// <returns>Returns the logged in user.</returns>
        TUser Login(string username, string password, string domain);

        /// <summary>
        /// Finds user by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>Returns the user when it exists.</returns>
        TUser FindUser(string username);

        /// <summary>
        /// Finds user by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="domain">The domain friendly name.</param>
        /// <returns>Returns the user when it exists.</returns>
        TUser FindUser(string username, string domain);
    }

    public class LdapConfig
    {
        private Regex _preFilterRegex = null;
        private string _preFilterRegexString = null;

        /// <summary>
        /// Gets or sets the name of the friendly name. This is used only for debug or personal information.
        /// In the future it might be used within the logs in case you need to understand what's happening.
        /// </summary>
        /// <example>OpenLdap Server-A</example>
        /// <remarks>Optional</remarks>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the URL in order to access LDAP server.
        /// </summary>
        /// <example>localhost</example>
        /// <remarks>Required</remarks>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the port in order to connect to the LDAP server.
        /// </summary>
        /// <example>389</example>
        /// <remarks>Required</remarks>
        public int Port { get; set; } = LdapConnection.DefaultPort;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="LdapConfig" /> is SSL.
        /// </summary>
        /// <value>
        ///   <c>true</c> if SSL; otherwise, <c>false</c>.
        /// </value>
        /// <example>false</example>
        /// <remarks>Not yet being used. Some issue while using the library with it.</remarks>
        public bool Ssl { get; set; }

        /// <summary>
        /// Gets or sets the DN. This actually sets the base for your LDAP configuration.
        /// </summary>
        /// <example>cn=ldap-ro,dc=contoso,dc=com</example>
        /// <remarks>Required</remarks>
        public string BindDn { get; set; }

        /// <summary>
        /// Gets or sets the bind credentials (password).
        /// </summary>
        /// <example>P@ss1W0Rd!</example>
        /// <remarks>Required</remarks>
        public string BindCredentials { get; set; }

        /// <summary>
        /// Gets or sets the search base for your users. If you don't specify, we can't search
        /// and validate your users credentials.
        /// </summary>
        /// <example>ou=users,DC=contoso,dc=com</example>
        public string SearchBase { get; set; }

        /// <summary>
        /// Gets or sets the search filter in order to find your user. The parameter {0} is used in order to
        /// fill the current user trying to connect.
        /// </summary>
        /// <example>(&(objectClass=posixAccount)(objectClass=person)(uid={0}))</example>
        /// <remarks>Required</remarks>
        public string SearchFilter { get; set; }

        /// <summary>
        /// Gets or sets the redis connection string. It follows the Redis library connection string
        /// format.
        /// </summary>
        /// <example>localhost:32771,ssl=false</example>
        /// <remarks>Optional, when multiple configuration it is being ignored and use the global configuration.</remarks>
        public string Redis { get; set; }

        /// <summary>
        /// Gets or sets the pre filter regex for discrimination. It is not yet supporting the /regex/ig format.
        /// </summary>
        /// <example>^(?![a|A]).*$</example>
        /// <remarks>Optional</remarks>
        public string PreFilterRegex
        {
            // TODO Could use something like https://stackoverflow.com/questions/12075927/serialization-of-regexp solution for regex
            get { return _preFilterRegexString; }
            set
            {
                // Compiled since it might be used quite a lot over time
                _preFilterRegex = new Regex(value, RegexOptions.Compiled);
                _preFilterRegexString = value;
            }
        }

        /// <summary>
        /// Gets or sets the refresh claims in seconds.
        /// </summary>
        /// <remarks>[Not fully implemented] Optional and if multiple take the general configuration (like redis)</remarks>
        public uint? RefreshClaimsInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the extra attributes. These extra attributes
        /// are the one from LDAP not part of the enum <see cref="LdapAttributes"/>.
        /// </summary>
        /// <remarks>Not being used in current implementation.</remarks>
        public string[] ExtraAttributes { get; set; }

        internal bool IsConcerned(string username)
        {
            if (_preFilterRegex == null)
            {
                return true;
            }

            return _preFilterRegex.IsMatch(username);
        }

        internal int FinalLdapConnectionPort
        {
            get
            {
                if (Port == 0)
                {
                    return Ssl ? LdapConnection.DefaultSslPort : LdapConnection.DefaultPort;
                }

                return Port;
            }
        }
    }

    public class ExtensionConfig
    {
        /// <summary>
        /// Gets or sets the redis connection string. It follows the Redis library connection string
        /// format.
        /// </summary>
        /// <example>localhost:32771,ssl=false</example>
        /// <remarks>Optional</remarks>
        public string Redis { get; set; }

        /// <summary>
        /// Gets or sets the LDAP configurations.
        /// </summary>
        public ICollection<LdapConfig> Connections { get; set; }

        /// <summary>
        /// Gets or sets the refresh claims in seconds.
        /// </summary>
        /// <remarks>[Not fully implemented] Optional</remarks>
        public uint? RefreshClaimsInSeconds { get; set; } = null;
    }

    public class LdapService<TUser> : ILdapService<TUser>
        where TUser : IAppUser, new()
    {
        private readonly ILogger<LdapService<TUser>> _logger;
        private readonly LdapConfig[] _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="LdapService{TUser}"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="logger">The logger.</param>
        public LdapService(ExtensionConfig config, ILogger<LdapService<TUser>> logger)
        {
            _logger = logger;
            _config = config.Connections.ToArray();
        }

        /// <summary>
        /// Logins using the specified credentials.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// Returns the logged in user.
        /// </returns>
        /// <exception cref="LoginFailedException">Login failed.</exception>
        public TUser Login(string username, string password)
        {
            return Login(username, password, null);
        }

        /// <summary>
        /// Logins using the specified credentials.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="domain">The domain friendly name.</param>
        /// <returns>
        /// Returns the logged in user.
        /// </returns>
        /// <exception cref="LoginFailedException">Login failed.</exception>
        public TUser Login(string username, string password, string domain)
        {
            //var searchResult = SearchUser(username, domain);

            //if (searchResult.Results.HasMore())
            //{
            //    try
            //    {
            //        var user = searchResult.Results.Next();
            //        if (user != null)
            //        {
            //            searchResult.LdapConnection.Bind(user.Dn, password);
            //            if (searchResult.LdapConnection.Bound)
            //            {
            //                //could change to ldap or change to configurable option
            //                var provider = !string.IsNullOrEmpty(domain) ? domain : "local";
            //                var appUser = new TUser();
            //                appUser.SetBaseDetails(user, provider, searchResult.config.ExtraAttributes); // Should we change to LDAP.
            //                searchResult.LdapConnection.Disconnect();

            //                return appUser;
            //            }
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        _logger.LogTrace(e.Message);
            //        _logger.LogTrace(e.StackTrace);
            //        throw new LoginFailedException("Login failed.", e);
            //    }
            //}

            //searchResult.LdapConnection.Disconnect();

            return default(TUser);
        }

        /// <summary>
        /// Finds user by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="domain">The domain friendly name.</param>
        /// <returns>
        /// Returns the user when it exists.
        /// </returns>
        public TUser FindUser(string username)
        {
            return FindUser(username, null);
        }

        /// <summary>
        /// Finds user by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="domain">The domain friendly name.</param>
        /// <returns>
        /// Returns the user when it exists.
        /// </returns>
        public TUser FindUser(string username, string domain)
        {
            //var searchResult = SearchUser(username, domain);

            //try
            //{
            //    var user = searchResult.Results.Next();
            //    if (user != null)
            //    {
            //        //could change to ldap or change to configurable option
            //        var provider = !string.IsNullOrEmpty(domain) ? domain : "local";
            //        var appUser = new TUser();
            //        appUser.SetBaseDetails(user, provider, searchResult.config.ExtraAttributes);

            //        searchResult.LdapConnection.Disconnect();

            //        return appUser;
            //    }
            //}
            //catch (Exception e)
            //{
            //    _logger.LogTrace(default(EventId), e, e.Message);
            //    // Swallow the exception since we don't expect an error from this method.
            //}

            //searchResult.LdapConnection.Disconnect();

            return default(TUser);
        }

        //private (ILdapSearchResults Results, LdapConnection LdapConnection, LdapConfig config) SearchUser(string username, string domain)
        //{
        //    var allSearcheable = _config.Where(f => f.IsConcerned(username)).ToList();
        //    if (!string.IsNullOrEmpty(domain))
        //    {
        //        allSearcheable = allSearcheable.Where(e => e.FriendlyName.Equals(domain)).ToList();
        //    }

        //    if (allSearcheable == null || allSearcheable.Count() == 0)
        //    {
        //        throw new LoginFailedException(
        //            "Login failed.",
        //            new NoLdapSearchableException("No searchable LDAP"));
        //    }

        //    // Could become async
        //    foreach (var matchConfig in allSearcheable)
        //    {
        //        using (var ldapConnection = new LdapConnection
        //        {
        //            SecureSocketLayer = matchConfig.Ssl
        //        })
        //        {
        //            ldapConnection.Connect(matchConfig.Url, matchConfig.FinalLdapConnectionPort);
        //            ldapConnection.Bind(matchConfig.BindDn, matchConfig.BindCredentials);
        //            var attributes = new TUser().LdapAttributes;

        //            var extrafieldList = new List<string>();

        //            if (matchConfig.ExtraAttributes != null)
        //            {
        //                extrafieldList.AddRange(matchConfig.ExtraAttributes);
        //            }

        //            attributes = attributes.Concat(extrafieldList).ToArray();

        //            var searchFilter = string.Format(matchConfig.SearchFilter, username);
        //            var result = ldapConnection.Search(
        //                matchConfig.SearchBase,
        //                LdapConnection.ScopeSub,
        //                searchFilter,
        //                attributes,
        //                false
        //            );

        //            if (result.HasMore()) // Count is async (not waiting). The hasMore() always works.
        //            {
        //                return (Results: result as LdapSearchResults, LdapConnection: ldapConnection, matchConfig);
        //            }
        //        }
        //    }

        //    throw new LoginFailedException(
        //            "Login failed.",
        //            new UserNotFoundException("User not found in any LDAP."));
        //}
    }

    internal class Any
    {
    }
}