using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Self.Improvement.Data.Entities;
using Self.Improvement.Data.Enums;

namespace Self.Improvement.Domain.Services.Interfaces
{
    public interface IGoalService
    {
        public Task<Goal> GetGoalById(Guid goalId);
        public Task<IEnumerable<Goal>> GetGoalsByUserId(Guid userId);
        public Task<Goal> UpdateGoal (Goal goal);
        public Task<Goal> UpdateGoalStatus (Guid goalId, GoalStatus goalStatus);
        public Task<Goal> AddGoal (Goal goal);
        public Task<bool> RemoveGoalById (Guid goalId);
    }
}
