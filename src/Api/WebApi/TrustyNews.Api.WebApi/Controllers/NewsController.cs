using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TrustyNews.Common.Models.RequestModels.News.Bookmark.Create;
using TrustyNews.Common.Models.RequestModels.News.Bookmark.Delete;
using TrustyNews.Common.Models.RequestModels.News.Create;
using TrustyNews.Common.Models.RequestModels.News.Tag.Create;
using TrustyNews.Common.Models.RequestModels.News.Vote.Create;
using TrustyNews.Common.Models.RequestModels.News.Vote.Delete;

namespace TrustyNews.Api.WebApi.Controllers
{
    /// <summary>
    /// TODO proplari {} ile al
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IMediator mediator;

        public NewsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateNewsCommand command)
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        [Route("Vote/Create")]
        public async Task<IActionResult> CreateVote([FromBody] CreateNewsVoteCommand command)
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        [Route("Vote/Delete")]
        public async Task<IActionResult> DeleteVote([FromBody] DeleteNewsVoteCommand command)
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        [Route("Bookmark/Create")]
        public async Task<IActionResult> CreateBookmark([FromBody] CreateNewsBookmarkCommand command)
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        [Route("Bookmark/Delete")]
        public async Task<IActionResult> DeleteBookmark([FromBody] DeleteNewsBookmarkCommand command)
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        [Route("Tag/Create")]
        public async Task<IActionResult> CreateTag([FromBody] CreateNewsTagCommand command)
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        [Route("Tag/Delete")]
        public async Task<IActionResult> DeleteTag([FromBody] DeleteNewsTagCommand command)
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }
    }
}
