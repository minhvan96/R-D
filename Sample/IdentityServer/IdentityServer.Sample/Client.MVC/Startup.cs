using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IdentityModel.Tokens.Jwt;

namespace Client.MVC
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
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";

                // When we need user to login, we will be using the OpenID Connect Protocols
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies") // Add Handler that can process cookies
                .AddOpenIdConnect("oidc", options =>
                {
                    // where the trusted token service is located (Identity Server)
                    options.Authority = "https://localhost:5001";

                    options.ClientId = "client_mvc";
                    options.ClientSecret = "client_mvc_secret";

                    // Authorization flow type
                    // ResponseType value:
                    // code: Authorization Code Flow
                    // id_token: Implicit Flow
                    // id_token token: Implicit Flow
                    // code id_token: Hybrid Flow
                    // code token: Hybrid Flow
                    // code id_token token: Hybrid Flow
                    options.ResponseType = "code";

                    // Persist the Tokens from Identity Server in the Cookie (As they will be needed later)
                    options.SaveTokens = true;

                    options.Scope.Add("profile");
                    options.Scope.Add("Api.One");
                    options.Scope.Add("offline_access");
                    options.GetClaimsFromUserInfoEndpoint = true;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // RequireAuthorization disables anonymous acceess for the entire application
                endpoints.MapDefaultControllerRoute()
                    .RequireAuthorization();
            });
        }
    }
}