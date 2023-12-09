using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TrustyNews.Api.Core.Application.Features.Commands.News.Bookmark.CreateBookmark;
using TrustyNews.Api.Core.Application.Features.Commands.News.Bookmark.DeleteBookmark;
using TrustyNews.Api.Core.Application.Features.Commands.News.Create;
using TrustyNews.Api.Core.Application.Features.Commands.News.Tag.CreateTag;
using TrustyNews.Api.Core.Application.Features.Commands.News.Tag.DeleteTag;
using TrustyNews.Api.Core.Application.Features.Commands.News.Vote.CreateVote;
using TrustyNews.Api.Core.Application.Features.Commands.News.Vote.DeleteVote;
using TrustyNews.Api.Core.Application.Features.Queries.News.GetMainPageNews;
using TrustyNews.Api.Core.Application.Features.Queries.News.GetNews;

namespace TrustyNews.Api.WebApi.Controllers
{
    /// <summary>
    /// TODO proplari {} ile al
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : BaseController
    {
        private readonly IMediator mediator;

        public NewsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetNews([FromQuery] GetNewsQuery query)
        {
            var news = await mediator.Send(query);

            return Ok(news);
        }
        [HttpGet]
        [Route("MainPageNews")]
        public async Task<IActionResult> GetMainPageNews(int page, int pageSize) 
        {
            var news = await mediator.Send(new GetMainPageNewsQuery(UserId, page, pageSize));

            return Ok(news);
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
