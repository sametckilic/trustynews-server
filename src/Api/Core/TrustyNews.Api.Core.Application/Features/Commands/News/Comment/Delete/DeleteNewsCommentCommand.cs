using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Api.Core.Application.Features.Commands.News.Comment.Delete
{
    public class DeleteNewsCommentCommand : IRequest<bool>
    {
        public DeleteNewsCommentCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id {  get; set; }
    }
}
