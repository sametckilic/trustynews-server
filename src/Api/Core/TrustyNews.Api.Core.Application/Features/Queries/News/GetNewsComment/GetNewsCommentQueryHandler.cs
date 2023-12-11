using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Features.Queries.User.GetUserDetail;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Common.Infrastructure.Extensions;
using TrustyNews.Common.Models.Page;
using TrustyNews.Common.Models.Queries;

namespace TrustyNews.Api.Core.Application.Features.Queries.News.GetNewsComment
{
    public class GetNewsCommentQueryHandler : IRequestHandler<GetNewsCommentQuery, PagedViewModel<GetNewsCommentViewModel>>
    {
        private readonly INewsCommentRepository newsCommentRepository;

        public GetNewsCommentQueryHandler(INewsCommentRepository newsCommentRepository)
        {
            this.newsCommentRepository = newsCommentRepository;
        }

        public async Task<PagedViewModel<GetNewsCommentViewModel>> Handle(GetNewsCommentQuery request, CancellationToken cancellationToken)
        {
            var query = newsCommentRepository.AsQueryable();

            query = query.Include(i => i.CreatedBy)
                         .Where(i => i.NewsId == request.NewsId);

            var list = query.Select(i => new GetNewsCommentViewModel()
            {
                Content = i.Content,
                CreateDate = i.CreateDate,
                CreatedByUserName = i.CreatedBy.UserName,
                Id = i.Id,
                PhotoBase = i.CreatedBy.UserPhoto.PhotoBase
            });

            var comments = await list.GetPaged(request.Page, request.PageSize);
            
            return comments;


        }
    }
}
