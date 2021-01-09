namespace IdentityServerAuthorizationService
{
    public interface IAppAuthorizationService
    {
        bool IsAdmin(string username, string providerClaimValue);

        bool BobIsAnAdmin(string name);
    }
}