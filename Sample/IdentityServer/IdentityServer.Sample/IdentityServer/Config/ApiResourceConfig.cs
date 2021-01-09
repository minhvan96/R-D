using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Config
{
    public static class ApiResourceConfig
    {
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("api_hybrid_flow")
                {
                    ApiSecrets={new Secret("api.hybrid_flow_secret".Sha256()) },

                    Scopes= { "client_hybrid_flow_api_scope" },

                    UserClaims = {"role", "admin", "user"}
                }
            };
    }
}