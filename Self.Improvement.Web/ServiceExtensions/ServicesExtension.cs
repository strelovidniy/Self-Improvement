using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Self.Improvement.Data.Entities;
using Self.Improvement.Data.Infrastructure;
using Self.Improvement.Domain.Configs;
using Self.Improvement.Domain.Services.Implementations;
using Self.Improvement.Domain.Services.Interfaces;
using Self.Improvement.Domain.TelegramBot;
using Telegram.Bot.Types;
using Message = Self.Improvement.Data.Entities.Message;
using User = Self.Improvement.Data.Entities.User;

namespace Self.Improvement.Web.ServiceExtensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IRepository<Message>, Repository<Message>>();
            services.AddTransient<IRepository<Goal>, Repository<Goal>>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IGoalService, GoalService>();

            services.AddTransient<ITelegramService, TelegramService>();
            services.AddSingleton<ITelegramHandlersService, TelegramHandlersService>();
            services.AddSingleton(provider => new ChatBot(provider.GetService<IOptions<ChatBotConfig>>()));
        }
    }
}
