using IdentityServer4.Models;
using System.Collections.Generic;

namespace VnR.IdentityServer.Config
{
    public static class ClientConfig
    {
        public static IEnumerable<Client> Clients =>
            new[]
            {
                // MVC client using hybrid flow
                new Client
                {
                    ClientId = "vnr_client_mvc_hybrid_client",
                    ClientName = "MVC Hybrid Client",

                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    ClientSecrets = { new Secret("vnr_client_mvc_hybrid_client_secret".Sha256()) },
                    RequirePkce = false,
                    RedirectUris = { "https://localhost:44381/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44381/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44381/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    //AlwaysIncludeUserClaimsInIdToken = true,
                    AllowedScopes = { "openid", "profile", "offline_access", "vrn_client_mvc_hybrid_scope" }
                }
            };
    }
}