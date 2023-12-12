using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TrustyNews.Api.Core.Application.Features.Commands.News.Bookmark.CreateBookmark;
using TrustyNews.Api.Core.Application.Features.Commands.News.Bookmark.DeleteBookmark;
using TrustyNews.Api.Core.Application.Features.Commands.News.Comment;
using TrustyNews.Api.Core.Application.Features.Commands.News.Comment.Create;
using TrustyNews.Api.Core.Application.Features.Commands.News.Comment.Delete;
using TrustyNews.Api.Core.Application.Features.Commands.News.Create;
using TrustyNews.Api.Core.Application.Features.Commands.News.Tag.CreateTag;
using TrustyNews.Api.Core.Application.Features.Commands.News.Tag.DeleteTag;
using TrustyNews.Api.Core.Application.Features.Commands.News.Vote.CreateVote;
using TrustyNews.Api.Core.Application.Features.Commands.News.Vote.DeleteVote;
using TrustyNews.Api.Core.Application.Features.Queries.News.GetMainPageNews;
using TrustyNews.Api.Core.Application.Features.Queries.News.GetNews;
using TrustyNews.Api.Core.Application.Features.Queries.News.GetNewsComment;
using TrustyNews.Api.Core.Application.Features.Queries.News.GetUserNews;
using TrustyNews.Api.Core.Application.Features.Queries.News.SearchBySubjectOrTags;

namespace TrustyNews.Api.WebApi.Controllers
{
    /// <summary>
    /// TODO required proplari {} ile al
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
        public async Task<IActionResult> GetMainPageNews(int page =1 , int pageSize= 10) 
        {
            var news = await mediator.Send(new GetMainPageNewsQuery(UserId, page, pageSize));

            return Ok(news);
        }
        [HttpGet]
        [Route("GetUserNews")]
        public async Task<IActionResult> GetUserNews(Guid userId, string userName, int page = 1, int pageSize= 10)
        {
            var news = await mediator.Send(new GetUserNewsQuery(userId, userName, page, pageSize));

            return Ok(news);    
        }
        [HttpGet]
        [Route("GetNewsComments/{newsId}")]
        public async Task<IActionResult> GetNewsComment(Guid newsId, int page = 1, int pageSize = 10)
        {
            var comments = await mediator.Send(new GetNewsCommentQuery(newsId, page, pageSize));

            return Ok(comments);
        }









        [HttpPost]
        [Route("Search/{searchText}")]
        public async Task<IActionResult> SearchBySubjectOrTag(string searchText)
        {
            var res = await mediator.Send(new SearchNewsBySubjectOrTagsQuery(searchText));

            return Ok(res); 
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
        [HttpPost]
        [Route("Comment/Create")]
        public async Task<IActionResult> CreateComment([FromBody] CreateNewsCommentCommand command)
        {
            var res = await mediator.Send(command);

            return Ok(res);
        }

        [HttpPost]
        [Route("Comment/Delete/{commentId}")]

        public async Task<IActionResult> DeleteComment(Guid commentId)
        {
            var res = await mediator.Send(new DeleteNewsCommentCommand(commentId));

            return Ok(res); 
        }
    }
}
