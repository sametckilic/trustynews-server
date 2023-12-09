using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Api.Core.Application.Features.Commands.News.Vote.DeleteVote
{
    public class DeleteNewsVoteCommand : IRequest<bool>
    {
        public Guid CreatedById { get; set; }
        public Guid NewsId { get; set; }
    }
}
