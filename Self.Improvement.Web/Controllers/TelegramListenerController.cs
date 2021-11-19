using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Self.Improvement.Data.Enums;
using Self.Improvement.Domain.Services.Interfaces;
using Telegram.Bot.Types;
using Message = Self.Improvement.Data.Entities.Message;

namespace Self.Improvement.Web.Controllers
{
    [Route("api/v1/telegram-listener"), AllowAnonymous]
    public class TelegramListenerController : BaseApiController
    {
        private readonly IChatService _chatService;
        private readonly IBotHandlerService _botHandler;

        public TelegramListenerController(IChatService chatService, IBotHandlerService botHandler)
        {
            _chatService = chatService;
            _botHandler = botHandler;
            _botHandler.InitCommands();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Update update, CancellationToken cancellationToken)
        {
            try
            {
                _botHandler.HandleMessagesAsync(update, GetHostUrl());

                return Ok(update.Message.Text);
            }
            catch (Exception ex)
            {
                // send Exception messages to my own Chat

                await _chatService.SendMessageAsync(
                    new Message
                    {
                        ChatId = new Guid("146fc3d8-22c6-40dd-a052-2a7b853739bd"),
                        Date = DateTime.Now,
                        FromBot = true,
                        Id = new Guid(),
                        Status = MessageStatus.Unread,
                        TelegramChatId = 234234234,
                        Text = JsonConvert.SerializeObject(update),
                    },
                    GetHostUrl()
                );

                await _chatService.SendMessageAsync(
                    new Message
                    {
                        ChatId = new Guid("146fc3d8-22c6-40dd-a052-2a7b853739bd"),
                        Date = DateTime.Now,
                        FromBot = true,
                        Id = new Guid(),
                        Status = MessageStatus.Unread,
                        TelegramChatId = 234234234,
                        Text = JsonConvert.SerializeObject(ex),
                    },
                    GetHostUrl()
                );
            }

            return Ok(null);
        }
    }
}