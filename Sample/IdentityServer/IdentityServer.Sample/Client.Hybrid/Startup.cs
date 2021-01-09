using IdentityServerAuthorizationService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Client.Hybrid
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly string identityServerUrl = "https://localhost:44364";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                options.DefaultSignOutScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect(options =>
            {
                options.SignInScheme = "Cookies";
                options.SignOutScheme = "OpenIdConnect";
                options.Authority = identityServerUrl;
                options.RequireHttpsMetadata = true;
                options.ClientId = "client_hyrbrid_flow";
                options.ClientSecret = "client_hybrid_flow_secret";
                options.ResponseType = "code id_token";
                options.Scope.Add("client_hybrid_flow_api_scope");
                options.Scope.Add("profile");
                options.Scope.Add("offline_access");
                options.GetClaimsFromUserInfoEndpoint = true;
                options.ClaimActions.MapAll();
                options.SaveTokens = true;
                // Set the correct name claim type
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name"
                };
            });

            services.AddSingleton<IAppAuthorizationService, AppAuthorizationService>();
            services.AddSingleton<IAuthorizationHandler, BobIsAnAdmin>();
            services.AddTransient<IAuthorizationHandler, IsAdminHandlerWithAge>();

            services.AddSingleton<IAuthorizationHandler, IsAdminHandler>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireWindowsProviderPolicy", Policies.GetRequireWindowsProviderPolicy());
                options.AddPolicy("IsAdminRequirementPolicy", policyIsAdminRequirement =>
                {
                    policyIsAdminRequirement.Requirements.Add(new IsAdminRequirement());
                });
            });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            IdentityModelEventSource.ShowPII = true;

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
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}