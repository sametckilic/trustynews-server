using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Common.Infrastructure.Extensions;
using TrustyNews.Common.Models.Page;
using TrustyNews.Common.Models.Queries;

namespace TrustyNews.Api.Core.Application.Features.Queries.News.GetUserNews
{
    public class GetUserNewsQueryHandler : IRequestHandler<GetUserNewsQuery, PagedViewModel<GetUserNewsViewModel>>
    {
        private readonly INewsRepository newsRepository;

        public GetUserNewsQueryHandler(INewsRepository newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public async Task<PagedViewModel<GetUserNewsViewModel>> Handle(GetUserNewsQuery request, CancellationToken cancellationToken)
        {
            var query = newsRepository.AsQueryable();

            if(request.UserId != null && request.UserId.HasValue)
            {
                query = query.Where(i => i.CreatedById == request.UserId);
            }
            else if(!string.IsNullOrEmpty(request.UserName))
            {
                query = query.Where(i => i.CreatedBy.UserName == request.UserName);
            }
            else
               return null;

            query = query
                  .Include(i => i.NewsCoverPhoto)
                  .Include(i => i.NewsBookmarks);

            var list = query.Select(i => new GetUserNewsViewModel()
            {
                Id = i.Id,
                Subject = i.Subject,
                IsTrusty = i.IsTrusty,
                PhotoBase = i.NewsCoverPhoto.PhotoBase,
                CreateDate = i.CreateDate,
                BookmarkedCount = i.NewsBookmarks.Count,
            });

            var entires = await list.GetPaged(request.Page, request.PageSize);

            return entires;
        }
    }
}
