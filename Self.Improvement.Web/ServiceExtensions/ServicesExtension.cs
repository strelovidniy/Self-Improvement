using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Self.Improvement.Domain.Configs;
using Self.Improvement.Domain.Services.Implementations;
using Self.Improvement.Domain.Services.Interfaces;
using Self.Improvement.Domain.TelegramBot;

namespace Self.Improvement.Web.ServiceExtensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITelegramService, TelegramService>();
            services.AddTransient<ITelegraHandlersService, TelegramHandlersService>();
            services.AddSingleton(provider => new ChatBot(provider.GetService<IOptions<ChatBotConfig>>()));
        }
    }
}
