using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Self.Improvement.Data.Entities;

namespace Self.Improvement.Domain.Services.Interfaces
{
    public interface IMessageService
    {
        public Task<Message> GetMessageByIdAsync(Guid messageId);
        public Task<IEnumerable<Message>> GetMessagesByChatIdAsync(Guid userId);
        public Task<Message> AddMessageAsync(Message message);
    }
}
