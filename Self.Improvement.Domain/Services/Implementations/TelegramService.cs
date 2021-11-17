using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Self.Improvement.Domain.Configs;
using Self.Improvement.Domain.Services.Interfaces;
using Self.Improvement.Domain.TelegramBot;
using Telegram.Bot.Types;

namespace Self.Improvement.Domain.Services.Implementations
{
    public class TelegramService : ITelegramService
    {
        private readonly ChatBot _bot;
        private readonly IOptions<ChatBotConfig> _accesToken;
        private readonly ITelegramHandlersService _tgHandler;

        public TelegramService(ChatBot bot, IOptions<ChatBotConfig> accesToken, ITelegramHandlersService tgHandler)
        {
            _bot = bot;
            _accesToken = accesToken;
            _tgHandler = tgHandler;
        }

        public void StartTelegramBot()
        {
            _bot.Init(_accesToken.Value.AccessToken);
            _bot.Start(_tgHandler.HandleUpdateAsync, _tgHandler.HandleErrorAsync);
        }
    }
}
