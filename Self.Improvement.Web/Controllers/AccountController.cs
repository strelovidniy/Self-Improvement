using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Self.Improvement.Domain.Services.Interfaces;

namespace Self.Improvement.Web.Controllers
{
    [AllowAnonymous, Route("account")]
    public class AccountController : Controller
    {
        private readonly string _userEmail;
        private readonly IAccountService _accountService;
        
        public AccountController(IHttpContextAccessor httpContextAccessor, IAccountService accountService)
        {
            _accountService = accountService;
            _userEmail = httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value;
        }
        
        [Route("google-login")]
        public IActionResult GoogleLogin()
        {
            var authProperties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(authProperties, GoogleDefaults.AuthenticationScheme);
        }
        
        [Route("google-response")]
        public async Task<IActionResult> GoogleResponse(CancellationToken ct)
        {
            await _accountService.CreateNewUserIfNotExistAsync(User.FindFirst(ClaimTypes.Email)?.Value,
                User.FindFirst(ClaimTypes.Name)?.Value, ct);
            return Redirect($"${Request.Scheme}://{Request.Host.Value}/home");
        }
        
        [Route("permission")]
        public async Task<IActionResult> CheckGetUserPermission(CancellationToken ct)
        {
            var authorizationData = await _accountService.GetUserAuthorizationDataAsync(_userEmail, ct);
            return authorizationData is not null ? Ok(authorizationData) : Unauthorized();
        }
    }
}