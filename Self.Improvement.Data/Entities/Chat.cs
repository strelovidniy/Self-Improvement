using System;
using System.Collections.Generic;
using Self.Improvement.Data.Enums;

namespace Self.Improvement.Data.Entities
{
    public class Chat : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public int? TelegramChatId { get; set; }
        public bool HasUnreadMessages { get; set; }
        public IEnumerable<Message> Messages { get; set; }
        public ChatStatus Status { get; set; }
    }
}
