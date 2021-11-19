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
    [Route("api/v1/account"), AllowAnonymous]
    public class AccountController : BaseApiController
    {
        private readonly string _userEmail;
        private readonly IAccountService _accountService;
        
        public AccountController(IHttpContextAccessor httpContextAccessor, IAccountService accountService)
        {
            _accountService = accountService;
            _userEmail = httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value;
        }
        
        [Route("google-login")]
        public IActionResult GoogleLoginAsync()
        {
            var authProperties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(authProperties, GoogleDefaults.AuthenticationScheme);
        }
        
        [Route("google-response")]
        public async Task<IActionResult> GoogleResponseAsync(CancellationToken ct)
        {
            await _accountService.CreateNewUserIfNotExistAsync(User.FindFirst(ClaimTypes.Email)?.Value,
                User.FindFirst(ClaimTypes.Name)?.Value, ct);
            return RedirectPermanent(GetHostUrl());
        }

        [Route("permission")]
        public async Task<IActionResult> CheckGetUserPermissionAsync(CancellationToken ct)
        {
            var authorizationData = await _accountService.GetUserAuthorizationDataAsync(_userEmail, ct);
            return authorizationData is not null ? Ok(authorizationData) : Unauthorized();
        }

        [Route("current-user")]
        public async Task<IActionResult> GetCurrentUserAsync(CancellationToken ct) =>
            Ok(await _accountService.GetUserByEmailAsync(_userEmail, ct));
    }
}