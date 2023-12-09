using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Common.Models.Page;
using TrustyNews.Common.Models.Queries;

namespace TrustyNews.Api.Core.Application.Features.Queries.News.GetMainPageNews
{
    public class GetMainPageNewsQuery : BasePagedQuery, IRequest<PagedViewModel<GetNewsDetailViewModel>>
    {
        public GetMainPageNewsQuery(Guid? userId, int page = 1, int pageSize= 10) : base(page, pageSize)
        {
            UserId = userId;
        }

        public Guid? UserId {  get; set; }
    }
}
