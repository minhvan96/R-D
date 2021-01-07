using Microsoft.AspNetCore.Mvc;
using Novell.Directory.Ldap;

using System.Threading.Tasks;

namespace Client.LDap.Controllers
{
    [Route("ldap_api/[controller]")]
    public class SimpleLDAPController : ControllerBase
    {
        public readonly string _domainName;

        public SimpleLDAPController()

        {
            _domainName = "192.168.1.18";
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string userDn = UserFullId("administrator");
            try
            {
                using (var connection = new LdapConnection { SecureSocketLayer = false })
                {
                    connection.Connect(_domainName, LdapConnection.DefaultPort);
                    connection.Bind(userDn, "Zxcvbnm!@#$%2021");
                    if (connection.Bound)
                    {
                        var test = 1;
                    }
                }
            }
            catch (LdapException ex)
            {
                return Ok(ex);
            }

            // User not authenticated
            //return Task.FromResult(AuthenticateResult.Fail("Invalid auth key."));
            return Ok(1);
        }

        private string UserFullId(string userId)
        {
            string value = string.Format(@"{0}@{1}", userId, _domainName);
            return value;
        }
    }
}