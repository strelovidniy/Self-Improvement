using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Self.Improvement.Data.Entities;
using Self.Improvement.Data.Enums;
using Self.Improvement.Data.Infrastructure;
using Self.Improvement.Domain.Services.Interfaces;

namespace Self.Improvement.Domain.Services.Implementations
{
    public class GoalService : IGoalService
    {
        private readonly IRepository<Goal> _goalRepository;

        public GoalService(IRepository<Goal> goalRepository) =>
            _goalRepository = goalRepository;

        public async Task<Goal> GetGoalByIdAsync(Guid goalId) =>
            await _goalRepository.GetByIdAsync(goalId);

        public async Task<IEnumerable<Goal>> GetGoalsByUserIdAsync(Guid userId) =>
            await _goalRepository.Query().Where(goal => goal.UserId == userId).ToListAsync();

        public async Task<IEnumerable<Goal>> GetActiveGoalsByUserIdAsync(Guid userId) =>
            await _goalRepository.Query().Where(goal => goal.UserId == userId && goal.Status == GoalStatus.Active).ToListAsync();

        public async Task<Goal> UpdateGoalAsync(Goal goal)
        {
            var updatingGoal = await GetGoalByIdAsync(goal.Id);

            if (updatingGoal == null) return null;

            updatingGoal.Status = goal.Status;
            updatingGoal.Description = goal.Description;
            updatingGoal.EndDate = goal.EndDate;
            updatingGoal.StartDate = goal.StartDate;

            await _goalRepository.SaveChangesAsync();

            return updatingGoal;
        }

        public async Task<Goal> UpdateGoalStatusAsync(Guid goalId, GoalStatus goalStatus)
        {
            var updatingGoal = await _goalRepository.GetByIdAsync(goalId);

            if (updatingGoal == null) return null;

            updatingGoal.Status = goalStatus;

            await _goalRepository.SaveChangesAsync();

            return updatingGoal;
        }

        public async Task<Goal> AddGoalAsync(Goal goal)
        {
            var addedGoal = await _goalRepository.AddAsync(goal);

            BackgroundJob.Schedule(() => SetGoalStatus(goal), TimeSpan.FromDays(1));

            await _goalRepository.SaveChangesAsync();

            return addedGoal;
        }

        public async Task<bool> RemoveGoalByIdAsync(Guid goalId)
        {
            var result = await _goalRepository.DeleteAsync(await GetGoalByIdAsync(goalId));

            await _goalRepository.SaveChangesAsync();

            return result;
        }

        private void SetGoalStatus(Goal goal)
        {
            if (DateTime.UtcNow < goal.StartDate)
            {
                goal.Status = GoalStatus.Pending;
            }
            else if (DateTime.UtcNow > goal.StartDate && DateTime.UtcNow < goal.EndDate)
            {
                goal.Status = GoalStatus.Active;
            }
            else
            {
                goal.Status = GoalStatus.Completed;
            }
        }
    }
}
