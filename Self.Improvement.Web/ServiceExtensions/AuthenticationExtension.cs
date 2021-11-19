using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Self.Improvement.Domain.Configs;

namespace Self.Improvement.Web.ServiceExtensions
{
    public static class AuthenticationExtension
    {
        public static void AddGoogleAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var secOpts = configuration
                .GetSection("GoogleOAuthConfig")
                .Get<GoogleOAuthConfig>();

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                }).AddCookie(options =>
                {
                    // TODO: Change to Login page
                    options.LoginPath = "/api/v1/account/google-login";
                    options.AccessDeniedPath = "/api/v1/account/google-login";
                })
                .AddGoogle(options =>
                {
                    options.ClientId = secOpts.ClientId;
                    options.ClientSecret = secOpts.ClientSecret;
                });
        }
    }
}
