using System.Collections.Generic;
using IdentityServer4.Admin.Admin.Configuration.Identity;

namespace IdentityServer4.Admin.Admin.Configuration.IdentityServer
{
    public class Client : global::IdentityServer4.Models.Client
    {
        public List<Claim> ClientClaims { get; set; } = new List<Claim>();
    }
}






