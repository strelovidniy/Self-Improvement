using System;
using Self.Improvement.Data.Enums;

namespace Self.Improvement.Domain.Models
{
    public class UserAuthorizationData
    {
        public Guid UserId { get; set; }
        public UserRole UserRole { get; set; } 
    }
}