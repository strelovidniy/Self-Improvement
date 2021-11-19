using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Self.Improvement.Data.Entities;
using Self.Improvement.Data.Enums;

namespace Self.Improvement.Domain.Services.Interfaces
{
    public interface IGoalService
    {
        public Task<Goal> GetGoalByIdAsync(Guid goalId);
        public Task<IEnumerable<Goal>> GetGoalsByUserIdAsync(Guid userId);
        public Task<IEnumerable<Goal>> GetActiveGoalsByUserIdAsync(Guid userId);
        public Task<Goal> UpdateGoalAsync (Goal goal);
        public Task<Goal> UpdateGoalStatusAsync (Guid goalId, GoalStatus goalStatus);
        public Task<Goal> AddGoalAsync (Goal goal);
        public Task<bool> RemoveGoalByIdAsync (Guid goalId);
    }
}
