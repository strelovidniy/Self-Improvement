using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Self.Improvement.Web.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        internal Guid GetUserId(int telegramId) => new();
    }
}