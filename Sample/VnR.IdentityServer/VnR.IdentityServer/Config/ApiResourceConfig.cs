using IdentityServer4.Models;
using System.Collections.Generic;

namespace VnR.IdentityServer.Config
{
    public static class ApiResourceConfig
    {
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("VnRHybridFlowResource")
                {
                    ApiSecrets =
                    {
                        new Secret("vrn_client_mvc_hybrid_scope".Sha256())
                    },
                    Scopes = { "vnr_hybrid_flow_api_resource_scope" },
                    UserClaims = { "role", "admin", "user" }
                }
            };
    }
}