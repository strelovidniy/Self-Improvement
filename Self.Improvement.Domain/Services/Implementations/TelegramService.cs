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
        #region Fields

        private readonly ChatBot _bot;
        private readonly IOptions<ChatBotConfig> _accesToken;
        private readonly ITelegramHandlersService _tgHandler;

        #endregion

        #region Ctor

        public TelegramService(ChatBot bot, IOptions<ChatBotConfig> accesToken, ITelegramHandlersService tgHandler)
        {
            _bot = bot;
            _accesToken = accesToken;
            _tgHandler = tgHandler;
        }

        #endregion

        #region Public Methods

        public void StartTelegramBot()
        {
            _bot.Init(_accesToken.Value.AccessToken);
            _bot.Start(_tgHandler.HandleUpdateAsync, _tgHandler.HandleErrorAsync);
        }

        #endregion
        
    }
}
