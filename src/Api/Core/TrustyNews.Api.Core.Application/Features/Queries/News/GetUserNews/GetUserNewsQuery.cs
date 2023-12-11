using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Common.Models.Page;
using TrustyNews.Common.Models.Queries;

namespace TrustyNews.Api.Core.Application.Features.Queries.News.GetUserNews
{
    public class GetUserNewsQuery : BasePagedQuery, IRequest<PagedViewModel<GetUserNewsViewModel>>
    {
        public GetUserNewsQuery(Guid? userId, string userName = null, int page = 1,int pageSize = 10): base(page,pageSize)
        {
            UserId = userId;
            UserName = userName;
        }

        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
    }
}
