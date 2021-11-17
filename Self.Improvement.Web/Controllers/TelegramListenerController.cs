using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Self.Improvement.Domain.Configs;
using Self.Improvement.Domain.Services.Interfaces;
using Self.Improvement.Domain.TelegramBot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;

namespace Self.Improvement.Web.Controllers
{
    [ApiController]
    [Route("api/v1/telegram-listener")]
    public class TelegramListenerController : BaseApiController
    {
        private readonly ChatBot _tgBot;
        private readonly IOptions<ChatBotConfig> _accesToken;
        private readonly ITelegramHandlersService _tgHandler;

        public TelegramListenerController(ChatBot tgBot, IOptions<ChatBotConfig> accesToken, ITelegramHandlersService tgHandler)
        {
            _tgBot = tgBot;
            _accesToken = accesToken;
            _tgHandler = tgHandler;
        }
        
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Update update, CancellationToken cancellationToken)
        {
            _tgBot.Init(_accesToken.Value.AccessToken);
            _tgBot.Start(_tgHandler.HandleUpdateAsync, _tgHandler.HandleErrorAsync);
            await _tgBot.Client.SendTextMessageAsync(update.Message.Chat.Id, "Hello");
            return Ok(update.Message.Text);
        }
    }
}