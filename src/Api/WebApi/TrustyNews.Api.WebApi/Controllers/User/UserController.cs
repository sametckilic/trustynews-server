using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TrustyNews.Api.Core.Application.Features.Commands.User.ChangePassword;
using TrustyNews.Api.Core.Application.Features.Commands.User.Create;
using TrustyNews.Api.Core.Application.Features.Commands.User.Login;
using TrustyNews.Api.Core.Application.Features.Commands.User.Update.UserPhoto;
using TrustyNews.Api.Core.Application.Features.Queries.User.GetUserDetail;

namespace TrustyNews.Api.WebApi.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMediator mediator;
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        [Route("GetUserDetail/{userId}")]
        public async Task<IActionResult> GetUserDetail(Guid userId)
        {
            var user = await mediator.Send(new GetUserDetailQuery(userId));

            return Ok(user);
        }







        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        [Route("ChangePassowrd")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        [Route("Update/UserPhoto")]
        public async Task<IActionResult> UpdateUserPhoto(IFormFile file, Guid userId)
        {
            var res = await mediator.Send(new UpdateUserPhotoCommand(file, userId));

            return Ok(res);
        }
    }
}
