using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Domain.Models;

namespace TrustyNews.Api.Core.Application.Features.Commands.News.Comment
{
    public class CreateNewsCommentCommand : IRequest<NewsComment>
    {
        public Guid NewsId { get; set; }
        public string Content { get; set; }
        public Guid CreatedById {  get; set; }
    }
}
