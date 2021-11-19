using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Self.Improvement.Web.Controllers
{
    [ApiController, Authorize(Policy = "User")]
    public class BaseApiController : ControllerBase
    {
        internal Guid GetUserId(int telegramId) => new();

        internal string GetHostUrl() => $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
    }
}