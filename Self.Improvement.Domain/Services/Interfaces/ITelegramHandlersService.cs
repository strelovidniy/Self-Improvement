using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Self.Improvement.Domain.TelegramBot
{
    public interface ITelegraHandlersService
    {
        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception,
            CancellationToken cancellationToken);
        
        public Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
            CancellationToken cancellationToken);
    }
}