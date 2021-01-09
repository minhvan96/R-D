using IdentityServer4.Admin.Shared.Configuration.Identity;
using IdentityServer4.Admin.STS.Identity.Configuration.Interfaces;

namespace IdentityServer4.Admin.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}





