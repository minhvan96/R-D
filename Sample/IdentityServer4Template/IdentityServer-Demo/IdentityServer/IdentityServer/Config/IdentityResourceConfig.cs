using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer.Config
{
    public static class IdentityResourceConfig
    {
        // Use for OpenID Connect
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
    }
}