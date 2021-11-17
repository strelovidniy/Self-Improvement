using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<Goal> GetGoalById(Guid goalId) =>
            await _goalRepository.GetByIdAsync(goalId);

        public async Task<IEnumerable<Goal>> GetGoalsByUserId(Guid userId) =>
            await _goalRepository.Query().Where(goal => goal.UserId == userId).ToListAsync();

        public async Task<Goal> UpdateGoal(Goal goal)
        {
            var updatingGoal = await GetGoalById(goal.Id);

            if (updatingGoal == null) return null;

            updatingGoal.Status = goal.Status;
            updatingGoal.Description = goal.Description;
            updatingGoal.EndDate = goal.EndDate;
            updatingGoal.StartDate = goal.StartDate;

            await _goalRepository.SaveChangesAsync();

            return updatingGoal;
        }

        public async Task<Goal> UpdateGoalStatus(Guid goalId, GoalStatus goalStatus)
        {
            var updatingGoal = await _goalRepository.GetByIdAsync(goalId);

            if (updatingGoal == null) return null;

            updatingGoal.Status = goalStatus;

            await _goalRepository.SaveChangesAsync();

            return updatingGoal;
        }

        public async Task<Goal> AddGoal(Goal goal)
        {
            var addedGoal = await _goalRepository.AddAsync(goal);

            await _goalRepository.SaveChangesAsync();

            return addedGoal;
        }

        public async Task<bool> RemoveGoalById(Guid goalId)
        {
            var result = await _goalRepository.DeleteAsync(await GetGoalById(goalId));

            await _goalRepository.SaveChangesAsync();

            return result;
        }
    }
}
