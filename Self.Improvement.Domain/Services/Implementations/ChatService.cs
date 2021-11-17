using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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