using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Common.Models.Page;
using TrustyNews.Common.Models.Queries;

namespace TrustyNews.Api.Core.Application.Features.Queries.News.GetNewsComment
{
    public class GetNewsCommentQuery :BasePagedQuery, IRequest<PagedViewModel<GetNewsCommentViewModel>>
    {
        public GetNewsCommentQuery(Guid newsId, int page = 1, int pageSize = 10) : base(page, pageSize)
        {
            NewsId = newsId;
        }

        public Guid NewsId { get; set; }
    }
}
