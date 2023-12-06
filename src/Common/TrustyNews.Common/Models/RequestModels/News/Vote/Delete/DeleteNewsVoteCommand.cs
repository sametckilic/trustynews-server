using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Common.Models.RequestModels.News.Vote.Delete
{
    public class DeleteNewsVoteCommand : IRequest<bool>
    {
        public Guid CreatedById { get; set; }
        public Guid NewsId { get; set; }
    }
}
