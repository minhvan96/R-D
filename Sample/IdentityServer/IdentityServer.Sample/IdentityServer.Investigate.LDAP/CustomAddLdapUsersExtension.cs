using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace IdentityServer.Investigate.LDAP
{
    public static class CustomAddLdapUsersExtension
    {
        public static IIdentityServerBuilder CustomAddLdapUsers<TUserDetails>(this IIdentityServerBuilder builder, IConfiguration configuration, UserStore userStore)
            where TUserDetails : IAppUser, new()
        {
            RegisterLdapConfigurations(builder, configuration);
            builder.Services.AddSingleton<ILdapService<TUserDetails>, LdapService<TUserDetails>>();

            // For testing purpose we can use the in memory. In reality it's better to have
            // your own implementation. An example with Redis exists in the repository
            //if (userStore == UserStore.InMemory)
            //{
            //    builder.Services.AddSingleton<ILdapUserStore, InMemoryUserStore<TUserDetails>>();
            //}
            //else
            //{
            //    builder.Services.AddSingleton<ILdapUserStore, RedisUserStore<TUserDetails>>();
            //}

            //builder.AddProfileService<LdapUserProfileService<TUserDetails>>(); // Claims? + ApplicationUser should be sent using a parameter
            //builder.AddResourceOwnerValidator<LdapUserResourceOwnerPasswordValidator<TUserDetails>>(); // Get user profiles

            return builder;
        }

        private static void RegisterLdapConfigurations(IIdentityServerBuilder builder, IConfiguration configuration)
        {
            // Consider multiple configuration as a default way of working
            var configs = (ExtensionConfig)configuration.Get(typeof(ExtensionConfig));

            // Fallback to one configuration in case the collection was containing 0.
            if (configs.Connections?.Count == null)
            {
                var config = (LdapConfig)configuration.Get(typeof(LdapConfig));

                configs.Redis = config.Redis;
                configs.RefreshClaimsInSeconds = config.RefreshClaimsInSeconds;
                configs.Connections = new List<LdapConfig> { config };
            }

            // Enforce a name for each.
            var configIndex = 0;
            configs.Connections.ToList().ForEach(f =>
            {
                configIndex++;
                f.FriendlyName = !string.IsNullOrEmpty(f.FriendlyName) ? f.FriendlyName : $"Config #{configIndex}";
            });

            builder.Services.AddSingleton(configs);
        }
    }
}