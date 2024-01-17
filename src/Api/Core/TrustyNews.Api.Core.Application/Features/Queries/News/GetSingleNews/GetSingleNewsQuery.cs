using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Common.Models.Queries;

namespace TrustyNews.Api.Core.Application.Features.Queries.News.GetSingleNews
{
    public class GetSingleNewsQuery : IRequest<GetNewsDetailViewModel>
    {
        public GetSingleNewsQuery(Guid? userId, Guid newsId)
        {
            UserId = userId;
            NewsId = newsId;
        }

        public Guid? UserId { get; set; }
        public Guid NewsId {  get; set; }

    }
}
