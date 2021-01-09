using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer.Config
{
    public static class ClientConfig
    {
        public static IEnumerable<Client> Clients =>
         new List<Client>
         {
                new Client
                {
                    ClientId = "client_console",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("client_console_secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "Api.One" }
                },
                new Client
                {
                    ClientId = "client_mvc",

                    ClientSecrets = { new Secret("client_mvc_secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    // where to redirect to after login
                    RedirectUris = { "https://localhost:5002/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                    AllowOfflineAccess = true,

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "Api.One"
                    }
                },
                new Client
                {
                    ClientId = "client_ldap",

                    ClientSecrets= {new Secret ("client_ldap_secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    AllowOfflineAccess = true,

                    AllowedScopes =new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "Api.One"
                    }
                },
                new Client
                {
                    ClientId = "client_hyrbrid_flow",
                    ClientName = "Hybrid MVC Client",

                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    ClientSecrets = { new Secret("client_hybrid_flow_secret".Sha256()) },
                    RequirePkce = false,
                    RedirectUris = { "https://localhost:44307/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44307/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44307/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    //AlwaysIncludeUserClaimsInIdToken = true,
                    AllowedScopes = { "openid", "profile", "offline_access",  "scope_used_for_hybrid_flow" }
                },
         };
    }
}