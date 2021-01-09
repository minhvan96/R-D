using IdentityServer4.Models;
using System.Collections.Generic;

namespace VnR.IdentityServer.Config
{
    public static class ApiScopeConfig
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("vrn_client_mvc_hybrid_scope", "Scope for the vrn_client_mvc_hybrid_scope"),
            };
    }
}