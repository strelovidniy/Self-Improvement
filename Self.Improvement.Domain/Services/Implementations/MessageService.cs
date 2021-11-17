using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Self.Improvement.Data.Infrastructure;
using Self.Improvement.Domain.Services.Interfaces;
using Message = Self.Improvement.Data.Entities.Message;

namespace Self.Improvement.Domain.Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> _messageRepository;
        private readonly ITelegramService _telegramService;

        public MessageService(
            IRepository<Message> messageRepository,
            ITelegramService telegramService
            )
        {
            _messageRepository = messageRepository;
            _telegramService = telegramService;
        }

        public async Task<Message> GetMessageByIdAsync(Guid messageId) =>
            await _messageRepository.GetByIdAsync(messageId);

        public async Task<IEnumerable<Message>> GetMessagesByChatIdAsync(Guid userId) =>
            await _messageRepository.Query().Where(message => message.ChatId == userId).ToListAsync();

        public async Task<Message> AddMessageAsync(Message message)
        {
            var addedMessage = await _messageRepository.AddAsync(message);

            await _messageRepository.SaveChangesAsync();

            if (!addedMessage.FromBot)
            {
                //await _telegramService.SendMessageAsync(new ChatId(addedMessage.TelegramChatId), addedMessage.Text);
            }

            return addedMessage;
        }
    }
}
