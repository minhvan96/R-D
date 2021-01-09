using IdentityServer.Config;
using IdentityServer.Data;
using IdentityServer.Data.Entities;
using IdentityServer.Data.TestData;
using IdentityServer.LdapExtension.Extensions;
using IdentityServer.LdapExtension.UserModel;
using IdentityServer4;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace IdentityServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationIdentityDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("SQLite")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IISOptions>(iis =>
            {
                iis.AuthenticationDisplayName = "Windows";
                iis.AutomaticAuthentication = true;
            });

            //InMemory
            var builder = services.AddIdentityServer()
                .AddInMemoryApiResources(ApiResourceConfig.ApiResources)
                .AddInMemoryIdentityResources(IdentityResourceConfig.IdentityResources)
                .AddInMemoryApiScopes(ApiScopeConfig.ApiScopes)
                .AddInMemoryClients(ClientConfig.Clients)
                //.AddLdapUsers<OpenLdapAppUser>(Configuration.GetSection("IdentityServerLdap"), UserStore.InMemory)
                .AddTestUsers(TestUsers.Users);

            #region Use later

            //string connectionString = Configuration.GetConnectionString("DefaultConnection");
            //var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            //var builder = services.AddIdentityServer(options =>
            //{
            //    options.Events.RaiseErrorEvents = true;
            //    options.Events.RaiseInformationEvents = true;
            //    options.Events.RaiseFailureEvents = true;
            //    options.Events.RaiseSuccessEvents = true;
            //    options.UserInteraction.LoginUrl = "/Account/Login";
            //    options.UserInteraction.LogoutUrl = "/Account/Logout";
            //    options.Authentication = new AuthenticationOptions()
            //    {
            //        CookieLifetime = TimeSpan.FromHours(10), // ID server cookie timeout set to 10 hours
            //        CookieSlidingExpiration = true
            //    };
            //})
            //.AddConfigurationStore(options =>
            //{
            //    options.ConfigureDbContext = b => b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
            //})
            //.AddOperationalStore(options =>
            //{
            //    options.ConfigureDbContext = b => b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
            //    options.EnableTokenCleanup = true;
            //});

            #endregion Use later

            builder.AddDeveloperSigningCredential();

            services.AddAuthentication()
                .AddGoogle("Google", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.ClientId = "782231625152-lpjmieqqss3lbsg4gqfh16ks3j5r7osp.apps.googleusercontent.com";
                    options.ClientSecret = "xcStYFUHTpFdzkVuzGHCrOFl";
                });
            //    .AddOpenIdConnect("oidc", "Demo IdentityServer", options =>
            //    {
            //        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
            //        options.SignOutScheme = IdentityServerConstants.SignoutScheme;
            //        options.SaveTokens = true;

            //        options.Authority = "https://demo.identityserver.io/";
            //        options.ClientId = "interactive.confidential";
            //        options.ClientSecret = "secret";
            //        options.ResponseType = "code";

            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            NameClaimType = "name",
            //            RoleClaimType = "role"
            //        };
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //InitializeDatabase(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

            var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
            context.Database.Migrate();
            if (!context.Clients.Any())
            {
                foreach (var client in ClientConfig.Clients)
                {
                    context.Clients.Add(client.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in IdentityResourceConfig.IdentityResources)
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.ApiScopes.Any())
            {
                foreach (var resource in ApiScopeConfig.ApiScopes)
                {
                    context.ApiScopes.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
        }
    }
}