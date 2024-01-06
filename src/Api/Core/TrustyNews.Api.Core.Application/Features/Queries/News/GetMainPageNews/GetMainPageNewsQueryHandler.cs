using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Common.Infrastructure.Extensions;
using TrustyNews.Common.Models;
using TrustyNews.Common.Models.Page;
using TrustyNews.Common.Models.Queries;

namespace TrustyNews.Api.Core.Application.Features.Queries.News.GetMainPageNews
{
    public class GetMainPageNewsQueryHandler : IRequestHandler<GetMainPageNewsQuery, PagedViewModel<GetNewsDetailViewModel>>
    {
        private readonly INewsRepository newsRepository;
        private readonly IMapper mapper;

        public GetMainPageNewsQueryHandler(INewsRepository newsRepository, IMapper mapper)
        {
            this.newsRepository = newsRepository;
            this.mapper = mapper;
        }

        public async Task<PagedViewModel<GetNewsDetailViewModel>> Handle(GetMainPageNewsQuery request, CancellationToken cancellationToken)
        {
            var query = newsRepository.AsQueryable();

            query = query.Include(i => i.NewsBookmarks)
                         .Include(i => i.CreatedBy)
                         .Include(i => i.NewsVotes)
                         .Include(i => i.NewsCoverPhoto);

            var list = query.Select(i => new GetNewsDetailViewModel()
            {
                Id = i.Id,
                Subject = i.Subject,
                Content = i.Content,
                IsBookmarked = request.UserId.HasValue && i.NewsBookmarks.Any(j => j.CreatedById == request.UserId) ? true : false,
                CreatedDate = i.CreateDate,
                NewsCoverPhotoBase = i.NewsCoverPhoto.PhotoBase,
                VoteType = request.UserId.HasValue && i.NewsVotes.Any(j => j.CreatedById == request.UserId) ?
                           i.NewsVotes.FirstOrDefault(j => j.CreatedById == request.UserId).VoteType :
                           VoteType.None,
                BookmarkedCount = i.NewsBookmarks.GroupBy(i => i.NewsId).Count(),
                CreatedByUserName = i.CreatedBy.UserName

            });;

            var entries = await list.GetPaged(request.Page, request.PageSize);

            return new PagedViewModel<GetNewsDetailViewModel>(entries.Results, entries.PageInfo);
        }
    }
}
