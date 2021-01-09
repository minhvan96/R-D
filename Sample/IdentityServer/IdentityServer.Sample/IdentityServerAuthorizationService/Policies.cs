using Microsoft.AspNetCore.Authorization;

namespace IdentityServerAuthorizationService
{
    public static class Policies
    {
        private static AuthorizationPolicy requireWindowsProviderPolicy;

        public static AuthorizationPolicy GetRequireWindowsProviderPolicy()
        {
            if (requireWindowsProviderPolicy != null) return requireWindowsProviderPolicy;

            requireWindowsProviderPolicy = new AuthorizationPolicyBuilder()
                  .RequireClaim("http://schemas.microsoft.com/identity/claims/identityprovider", "Windows")
                  .Build();

            return requireWindowsProviderPolicy;
        }
    }
}