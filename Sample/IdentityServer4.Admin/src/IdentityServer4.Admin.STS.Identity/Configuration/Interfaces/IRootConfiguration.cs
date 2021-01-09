using IdentityServer4.Admin.Shared.Configuration.Identity;

namespace IdentityServer4.Admin.STS.Identity.Configuration.Interfaces
{
    public interface IRootConfiguration
    {
        AdminConfiguration AdminConfiguration { get; }

        RegisterConfiguration RegisterConfiguration { get; }
    }
}





