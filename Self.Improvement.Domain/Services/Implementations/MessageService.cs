using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Self.Improvement.Data.Entities;
using Self.Improvement.Data.Infrastructure;
using Self.Improvement.Domain.Extensions.ServicesExtensions;
using Self.Improvement.Domain.Services.Interfaces;

namespace Self.Improvement.Domain.Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> _messageRepository;

        public MessageService(IRepository<Message> messageRepository) =>
            _messageRepository = messageRepository;

        public async Task<Message> GetMessageByIdAsync(Guid messageId) =>
            await _messageRepository.GetByIdAsync(messageId);

        public async Task<IEnumerable<Message>> GetMessagesByUserIdAsync(Guid userId) =>
            await _messageRepository.Query().Where(message => message.UserId == userId).ToListAsync();

        public async Task<Message> SendMessageAsync(Message message)
        {
            var addedMessage = await _messageRepository.AddAsync(message);

            await _messageRepository.SaveChangesAsync();

            return addedMessage;
        }
    }
}
