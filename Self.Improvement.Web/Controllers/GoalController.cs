using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Self.Improvement.Data.Entities;
using Self.Improvement.Data.Enums;
using Self.Improvement.Domain.Services.Interfaces;

namespace Self.Improvement.Web.Controllers
{
    [Route("api/v1/goals")]
    public class GoalController : Controller
    {
        private readonly IGoalService _goalService;

        public GoalController(IGoalService goalService) =>
            _goalService = goalService;

        [HttpGet("by-user/{userId:guid}")]
        public async Task<IActionResult> GetGoalsByUserIdAsync(Guid userId) => 
            Ok(await _goalService.GetGoalsByUserIdAsync(userId));

        [HttpGet("active/{userId:guid}")]
        public async Task<IActionResult> GetActiveGoalsByUserIdAsync(Guid userId) => 
            Ok(await _goalService.GetActiveGoalsByUserIdAsync(userId));

        [HttpGet("by-id/{goalId:guid}")]
        public async Task<IActionResult> GetGoalByIdAsync(Guid goalId) =>
            Ok(await _goalService.GetGoalByIdAsync(goalId));

        [HttpPost]
        public async Task<IActionResult> AddGoalAsync([FromBody] Goal goal) =>
            Ok(await _goalService.AddGoalAsync(goal));

        [HttpPut]
        public async Task<IActionResult> UpdateGoalAsync([FromBody] Goal goal) =>
            Ok(await _goalService.UpdateGoalAsync(goal));

        [HttpPut("{goalId:guid}")]
        public async Task<IActionResult> UpdateGoalStatusAsync(Guid goalId, [FromBody]GoalStatus goalStatus) =>
            Ok(await _goalService.UpdateGoalStatusAsync(goalId, goalStatus));


        [HttpDelete("{goalId:guid}")]
        public async Task<IActionResult> RemoveGoalByIdAsync(Guid goalId) =>
            Ok(await _goalService.RemoveGoalByIdAsync(goalId));
    }
}
