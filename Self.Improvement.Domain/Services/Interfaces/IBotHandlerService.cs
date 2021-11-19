using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Self.Improvement.Domain.Services.Interfaces
{
    public interface IBotHandlerService
    {
        public BotCommand StartCommand { get; set; }
        public void InitCommands();
        public Task HandleMessagesAsync(Update update, string hostUrl);
    }
}