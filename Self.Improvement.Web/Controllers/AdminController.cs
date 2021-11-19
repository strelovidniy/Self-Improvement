using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Self.Improvement.Data.Entities;
using Self.Improvement.Domain.Services.Interfaces;

namespace Self.Improvement.Web.Controllers
{
    [ApiController]
    [Route("api/v1/admin"), Authorize(Policy = "Admin")]
    public class AdminController : BaseApiController
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService) => 
            _userService = userService;

        [HttpGet("users")]
        public async Task<IActionResult> GetUsersAsync() =>
            Ok(await _userService.GetAllAsync());

        [HttpPut("users")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] User user) =>
            Ok(await _userService.UpdateUserAsync(user));

        [HttpPost("users")]
        public async Task<IActionResult> AddUserAsync([FromBody] User user) =>
            Ok(await _userService.AddUserAsync(user));

        [HttpDelete("users/{userId:guid}")]
        public async Task<IActionResult> DeleteUserByIdAsync(Guid userId) =>
            Ok(await _userService.RemoveUserByIdAsync(userId));
    }
}
