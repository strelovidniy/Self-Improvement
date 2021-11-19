using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Self.Improvement.Data.Entities;
using Self.Improvement.Data.Infrastructure;
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
            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IRepository<Message>, Repository<Message>>();
            services.AddTransient<IRepository<Goal>, Repository<Goal>>();
            services.AddTransient<IRepository<Chat>, Repository<Chat>>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IGoalService, GoalService>();
            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IAccountService, AccountService>();
            
            services.AddTransient<ITelegramBotService, TelegramBotService>();
            services.AddSingleton<IBotHandlerService, BotHandlerService>();
            services.AddSingleton(provider => new ChatBot(provider.GetService<IOptions<ChatBotConfig>>()));
        }
    }
}
