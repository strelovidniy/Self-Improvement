using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Self.Improvement.Data.Enums;
using Self.Improvement.Domain.Configs;
using Self.Improvement.Domain.Services.Interfaces;
using Self.Improvement.Domain.TelegramBot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Message = Self.Improvement.Data.Entities.Message;

namespace Self.Improvement.Web.Controllers
{
    [ApiController]
    [Route("api/v1/telegram-listener")]
    public class TelegramListenerController : BaseApiController
    {
        private readonly ChatBot _tgBot;
        private readonly IOptions<ChatBotConfig> _accesToken;
        private readonly ITelegramHandlersService _tgHandler;
        private readonly IChatService _chatService;

        public TelegramListenerController(
            ChatBot tgBot,
            IOptions<ChatBotConfig> accesToken,
            ITelegramHandlersService tgHandler,
            IChatService chatService
        )
        {
            _tgBot = tgBot;
            _accesToken = accesToken;
            _tgHandler = tgHandler;
            _chatService = chatService;
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] dynamic update, CancellationToken cancellationToken)
        {
            //_tgBot.Init(_accesToken.Value.AccessToken);
            //_tgBot.Start(_tgHandler.HandleUpdateAsync, _tgHandler.HandleErrorAsync);
            //await _tgBot.Client.SendTextMessageAsync(update.Message.Chat.Id, "Hello");
            await _chatService.SendMessageAsync(new Message
            {
                ChatId = new Guid("146fc3d8-22c6-40dd-a052-2a7b853739bd"),
                Date = DateTime.Now,
                FromBot = true,
                Id = new Guid(),
                Status = MessageStatus.Unread,
                TelegramChatId = 234234234,
                Text = "Bot Works",
            });

            //return Ok(update.Message.Text);
            return Ok(null);
        }
    }
}