using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer.Config
{
    public static class ApiScopeConfig
    {
        public static IEnumerable<ApiScope> ApiScopes =>
           new List<ApiScope>
           {
                new ApiScope("Api.One", "Api One"),
                new ApiScope(name: "read",   displayName: "Read your data."),
                new ApiScope(name: "write",  displayName: "Write your data."),
                new ApiScope(name: "delete", displayName: "Delete your data."),

                // Policy Server
                new ApiScope("policyserver.runtime"),
                new ApiScope("policyserver.management"),

               // Hybrid flow API Scope
               new ApiScope("client_hybrid_flow_api_scope", "Scope for the client_hybrid_flow_api_scope")
           };
    }
}