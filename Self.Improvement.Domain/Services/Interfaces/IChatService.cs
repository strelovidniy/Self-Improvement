using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Self.Improvement.Data.Entities;

namespace Self.Improvement.Domain.Services.Interfaces
{
    public interface IChatService
    {
        public Task<Chat> GetChatByUserIdAsync(Guid userId);
        public Task<Chat> GetChatByIdAsync(Guid userId);
        public Task<IEnumerable<Chat>> GetUnreadChatsAsync();
        public Task<IEnumerable<Chat>> GetReadChatsAsync();
        public Task<Message> SendMessageAsync(Message message);
    }
}
