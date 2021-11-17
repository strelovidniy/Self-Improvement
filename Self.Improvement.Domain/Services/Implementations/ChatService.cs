using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Self.Improvement.Data.Entities;
using Self.Improvement.Data.Enums;
using Self.Improvement.Data.Infrastructure;
using Self.Improvement.Domain.Extensions.ServicesExtensions;
using Self.Improvement.Domain.Services.Interfaces;

namespace Self.Improvement.Domain.Services.Implementations
{
    public class ChatService : IChatService
    {
        private readonly IRepository<Chat> _chatRepository;

        public ChatService(IRepository<Chat> chatRepository) =>
            _chatRepository = chatRepository;


        public async Task<Chat> OpenChatAsync(User user)
        {
            var chat = await GetChatByIdAsync(user.Id);

            if (chat is null)
            {
                chat = await _chatRepository.AddAsync(new Chat()
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

        public async Task<Message> SendMessageAsync(Message message)
        {
            if (message.FromBot)
            {
                var connection = new HubConnectionBuilder()
                    .WithUrl("https://self-improvement.azurewebsites.net/api/v1/chats/messages-hub")
                    .WithAutomaticReconnect()
                    .Build();

                await connection.StartAsync();

                await connection.InvokeAsync("EnterToGroup", message.ChatId.ToString());

                await connection.InvokeAsync("SendMessageToGroup", message);

                await connection.InvokeAsync("LeaveTheGroup", message.ChatId.ToString());

                await connection.StopAsync();
            }
            else
            {
                var telegramChatId = (await _chatRepository
                    .Query()
                    .FirstOrDefaultAsync(chat => chat.Id == message.ChatId)).TelegramChatId;

                if (telegramChatId is not null)
                {
                    // await _telegramService.SendMessageAsync(telegramChatId, message)
                }
            }

            return message;
        }

        public async Task<Message> ReceiveMessageAsync(Message message) =>
            AddMessageToChatAsync(message) is null ? null : message;

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
    }
}