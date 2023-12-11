using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Common.Models.Queries;

namespace TrustyNews.Api.Core.Application.Features.Queries.User.GetUserDetail
{
    public class GetUserDetailQuery : IRequest<GetUserDetailViewModel>
    {
        public GetUserDetailQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }

    }
}
