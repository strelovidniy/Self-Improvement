using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Self.Improvement.Domain.Configs;

namespace Self.Improvement.Web.ServiceExtensions
{
    public static class ConfigurationExtension
    {
        public static void ApplyConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ChatBotConfig>(configuration.GetSection("ChatBotConfig"));
        }
    }
}
