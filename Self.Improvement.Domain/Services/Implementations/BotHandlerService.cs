using System;
using System.Threading.Tasks;
using Self.Improvement.Data.Enums;
using Self.Improvement.Domain.Services.Interfaces;
using Telegram.Bot.Types;
using Message = Self.Improvement.Data.Entities.Message;

namespace Self.Improvement.Domain.Services.Implementations
{
    public class BotHandlerService : IBotHandlerService
    {
        private readonly ITelegramBotService _tgService;
        private readonly IChatService _chatService;

        private bool _isAuthorized = true;

        private bool _isChating;

        public BotCommand StartCommand { get; set; }
        public BotCommand SpecialistCommand { get; set; }
        public BotCommand GoalsCommand { get; set; }

        public BotHandlerService(
            ITelegramBotService tgService,
            IChatService chatService
        )
        {
            _tgService = tgService;
            _chatService = chatService;
        }

        public void InitCommands()
        {
            StartCommand = new BotCommand
            {
                Command = "/start",
                Description = "command to start the bot"
            };

            SpecialistCommand = new BotCommand
            {
                Command = "Specialist",
                Description = "command to call specialist"
            };

            GoalsCommand = new BotCommand
            {
                Command = "Specialist",
                Description = "command to view goals"
            };
        }

        public async Task HandleMessagesAsync(Update update, string hostUrl)
        {
            if (update.Message.Text == StartCommand.Command)
            {
                _tgService.StartCommandAsync(update, _isAuthorized);

                return;
            }

            if (update.Message.Text == SpecialistCommand.Command)
            {
                await _chatService.SendMessageAsync(
                    new Message
                    {
                        ChatId = await _chatService.GetChatIdByTelegramIdAsync((int)update.Message.Chat.Id),
                        Date = DateTime.Now,
                        FromBot = true,
                        Id = new Guid(),
                        Status = MessageStatus.Unread,
                        TelegramChatId = (int)update.Message.Chat.Id,
                        Text = "Chat started"
                    },
                    hostUrl
                );

                _isChating = true;

                return;
            }

            if (update.Message.Text == GoalsCommand.Command)
            {
                _tgService.StartCommandAsync(update, true);

                return;
            }

            if (_isChating)
                await _chatService.SendMessageAsync(
                    new Message
                    {
                        ChatId = await _chatService.GetChatIdByTelegramIdAsync((int)update.Message.Chat.Id),
                        Date = DateTime.Now,
                        FromBot = true,
                        Id = new Guid(),
                        Status = MessageStatus.Unread,
                        TelegramChatId = (int)update.Message.Chat.Id,
                        Text = update.Message.Text
                    },
                    hostUrl
                );
        }
    }
}
