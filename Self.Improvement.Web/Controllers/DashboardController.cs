using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Self.Improvement.Data.Entities;
using Self.Improvement.Data.Enums;
using Self.Improvement.Domain.Services.Interfaces;

namespace Self.Improvement.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        private readonly IGoalService _goalService;

        public DashboardController(IGoalService goalService) =>
            _goalService = goalService;

        [HttpGet]
        public async Task<IActionResult> GetGoalsByUserId()
        {
            // TODO: get user id
            Guid userId = Guid.NewGuid();

            var result = await _goalService.GetGoalsByUserId(userId);

            return Ok(result);
        }

        [HttpGet("{goalId:guid}")]
        public async Task<IActionResult> GetGoalById(Guid goalId) =>
            Ok(await _goalService.GetGoalById(goalId));

        [HttpPost]
        public async Task<IActionResult> AddGoal([FromBody] Goal goal) =>
            Ok(await _goalService.AddGoal(goal));

        [HttpPut]
        public async Task<IActionResult> UpdateGoal([FromBody] Goal goal) =>
            Ok(await _goalService.UpdateGoal(goal));

        [HttpPut("{goalId:guid}")]
        public async Task<IActionResult> UpdateGoalStatus(Guid goalId, GoalStatus goalStatus) =>
            Ok(await _goalService.UpdateGoalStatus(goalId, goalStatus));


        [HttpDelete("{goalId:guid}")]
        public async Task<IActionResult> RemoveGoalById(Guid goalId) =>
            Ok(await _goalService.RemoveGoalById(goalId));
    }
}
