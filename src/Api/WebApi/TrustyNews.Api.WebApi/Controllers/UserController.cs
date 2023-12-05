using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TrustyNews.Common.Models.RequestModels.User.ChangePassword;
using TrustyNews.Common.Models.RequestModels.User.Create;
using TrustyNews.Common.Models.RequestModels.User.Login;

namespace TrustyNews.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginUserCommand command)
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody]CreateUserCommand command)
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        [Route("ChangePassowrd")]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordCommand command)
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }
    }
}
