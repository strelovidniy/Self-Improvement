using System;
using System.Collections.Generic;
using Self.Improvement.Data.Enums;

namespace Self.Improvement.Data.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? TelegramId { get; set; }
        public UserRole Role { get; set; }
        public IEnumerable<Goal> Goals { get; set; }
        public Chat Chat { get; set; }
    }
}
