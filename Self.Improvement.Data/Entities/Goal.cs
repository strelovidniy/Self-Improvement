using System;
using Self.Improvement.Data.Enums;

namespace Self.Improvement.Data.Entities
{
    public class Goal : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public  Guid UserId { get; set; }
        public  string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public GoalStatus Status { get; set; }
    }
}
