using System;
using Self.Improvement.Data.Enums;

namespace Self.Improvement.Data.Entities
{
    public class Message : IEntity
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int TelegramChatId { get; set; }
        public bool FromBot { get; set; }
        public DateTime Date { get; set; }
        public Guid ChatId { get; set; }
        public MessageStatus Status { get; set; }
    }
}
