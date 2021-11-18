using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Self.Improvement.Data.Entities;
using Self.Improvement.Data.Enums;
using Self.Improvement.Data.Infrastructure;
using Self.Improvement.Domain.Configs;
using Self.Improvement.Domain.Extensions.ServicesExtensions;
using Self.Improvement.Domain.Services.Interfaces;
using Self.Improvement.Domain.TelegramBot;

namespace Self.Improvement.Domain.Services.Implementations
{
    public class ChatService : IChatService
    {
        private readonly IRepository<Chat> _chatRepository;
        private readonly ChatBot _telegramBot;
        private readonly IOptions<ChatBotConfig> _telegramBotConfig;
        private readonly IUserService _userService;

        public ChatService(
            IRepository<Chat> chatRepository,
            ChatBot telegramBot,
            IOptions<ChatBotConfig> telegramBotConfig,
            IUserService userService
        )
        {
            _chatRepository = chatRepository;
            _telegramBot = telegramBot;
            _telegramBotConfig = telegramBotConfig;
            _userService = userService;
        }


        public async Task<Chat> OpenChatAsync(User user)
        {
            var chat = await GetChatByIdAsync(user.Id);

            if (chat is null)
            {
                chat = await _chatRepository.AddAsync(new Chat
                {
                    Id = new Guid(),
                    Name = user.Name,
                    UserId = user.Id,
                    HasUnreadMessages = false,
                    Messages = new List<Message>(),
                    TelegramChatId = user.TelegramId,
                    Status = ChatStatus.Active
                });
            }
            else
            {
                chat.Status = ChatStatus.Active;
            }

            await _chatRepository.SaveChangesAsync();

            return chat;
        }

        public async Task<Chat> CloseChatAsync(Guid userId)
        {
            var chat = await GetChatByIdAsync(userId);

            if (chat is null) return null;

            chat.Status = ChatStatus.Active;

            await _chatRepository.SaveChangesAsync();

            return chat;
        }

        public Task<Chat> GetChatByIdAsync(Guid chatId) =>
            _chatRepository
                .Query()
                .IncludeMessages()
                .FirstOrDefaultAsync(chat => chat.Id == chatId);

        public async Task<Guid> GetChatIdByTelegramIdAsync(int telegramChatId)
        {
            var chat = await _chatRepository
                .Query()
                .FirstOrDefaultAsync(chat => chat.TelegramChatId == telegramChatId);

            if (chat is not null) return chat.Id;

            var userId = await _userService.GetUserIdByTelegramIdAsync(telegramChatId);

            chat = await _chatRepository.AddAsync(new Chat
            {
                HasUnreadMessages = false,
                Id = new Guid(),
                Messages = new List<Message>(),
                TelegramChatId = telegramChatId,
                Status = ChatStatus.Active,
                Name = (await _userService.GetUserByIdAsync(userId)).Name,
                UserId = userId
            });

            await _chatRepository.SaveChangesAsync();

            return chat.Id;
        }

        public async Task<IEnumerable<Chat>> GetUnreadChatsAsync() =>
            await _chatRepository
                .Query()
                .Where(chat => chat.HasUnreadMessages && chat.Status != ChatStatus.Deleted)
                .ToListAsync();

        public async Task<IEnumerable<Chat>> GetReadChatsAsync() =>
            await _chatRepository
                .Query()
                .Where(chat => !chat.HasUnreadMessages && chat.Status != ChatStatus.Deleted)
                .ToListAsync();

        public async Task<Message> SendMessageAsync(Message message, string hostUrl) =>
            message.FromBot
                ? await SendMessageToWebUIASync(message, hostUrl)
                : await SendMessageToTelegramAsync(message, hostUrl);

        public async Task<Message> ReceiveMessageAsync(Message message) =>
            await AddMessageToChatAsync(message);

        private async Task<Message> AddMessageToChatAsync(Message message)
        {
            var chat = await GetChatByIdAsync(message.ChatId);

            if (chat is null) return null;

            var messages = chat.Messages.ToList();

            messages.Add(message);

            chat.Messages = messages;

            await _chatRepository.SaveChangesAsync();

            return message;
        }

        private async Task<Message> SendMessageToWebUIASync(Message message, string hostUrl)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl($"{hostUrl}/api/v1/chats/messages-hub")
                .WithAutomaticReconnect()
                .Build();

            await connection.StartAsync();

            await connection.InvokeAsync("EnterToGroup", message.ChatId.ToString());

            await connection.InvokeAsync("SendMessageToGroup", message);

            await connection.InvokeAsync("LeaveTheGroup", message.ChatId.ToString());

            await connection.StopAsync();

            return message;
        }

        private async Task<Message> SendMessageToTelegramAsync(Message message, string hostUrl)
        {
            var telegramChatId = (await _chatRepository
                .Query()
                .FirstOrDefaultAsync(chat => chat.Id == message.ChatId)).TelegramChatId;

            if (telegramChatId is null) return message;

            try
            {
                _telegramBot.Init(_telegramBotConfig.Value.AccessToken);

                await _telegramBot.Client.SendTextMessageAsync(message.TelegramChatId, message.Text);
            }
            catch (Exception ex)
            {
                await SendMessageAsync(
                    new Message
                    {
                        ChatId = message.ChatId,
                        Date = message.Date,
                        FromBot = message.FromBot,
                        Id = message.Id,
                        Status = message.Status,
                        TelegramChatId = message.TelegramChatId,
                        Text = JsonConvert.SerializeObject(ex)
                    },
                    hostUrl
                );
            }

            return message;
        }
    }
}