using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TrustyNews.Api.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        //public Guid UserId => new(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        public Guid UserId => Guid.NewGuid();
    }
}
