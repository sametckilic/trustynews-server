using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Common.Models.RequestModels.News.Vote.Create
{
    public class CreateNewsVoteCommand : IRequest<bool>
    {
        public CreateNewsVoteCommand(Guid newsId, Guid createdById, VoteType voteType)
        {
            NewsId = newsId;
            CreatedById = createdById;
            VoteType = voteType;
        }

        public Guid NewsId { get; set; }
        public Guid CreatedById { get; set; }
        public VoteType VoteType { get; set; }
    }
}
