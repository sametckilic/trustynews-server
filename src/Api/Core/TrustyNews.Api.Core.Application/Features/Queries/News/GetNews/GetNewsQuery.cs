using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Common.Models.Queries;

namespace TrustyNews.Api.Core.Application.Features.Queries.News.GetNews
{
    public class GetNewsQuery : IRequest<List<GetNewsViewModel>>
    {
        public GetNewsQuery() { }
        public GetNewsQuery(Guid? userId)
        {
            UserId = userId;

        }

        public Guid? UserId {  get; set; }
        public bool TodaysNews { get; set; }
        public int Count { get; set; } = 10;
    }
}
