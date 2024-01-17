using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Common.Exceptions;
using TrustyNews.Common.Models;
using TrustyNews.Common.Models.Queries;

namespace TrustyNews.Api.Core.Application.Features.Queries.News.GetSingleNews
{
    public class GetSingleNewsQueryHandler : IRequestHandler<GetSingleNewsQuery, GetNewsDetailViewModel>
    {
        private readonly INewsRepository newsRepository;
        private readonly IUserPhotoRepository userPhotoRepository;

        public GetSingleNewsQueryHandler(INewsRepository newsRepository, IUserPhotoRepository userPhotoRepository)
        {
            this.newsRepository = newsRepository;
            this.userPhotoRepository = userPhotoRepository;
        }

        public Task<GetNewsDetailViewModel> Handle(GetSingleNewsQuery request, CancellationToken cancellationToken)
        {
            var query = newsRepository.AsQueryable();


            query = query.Include(i => i.NewsBookmarks)
                         .Include(i => i.CreatedBy)
                         .Include(i => i.NewsVotes)
                         .Include(i => i.NewsCoverPhoto)
                         .Where(i => i.Id == request.NewsId);

            if (query == null)
                throw new DatabaseValidationException("News not found!");


            var news = query.Select(i => new GetNewsDetailViewModel()
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
                CreatedByUserName = i.CreatedBy.UserName,
                UserPhotoBase = userPhotoRepository.GetUserPhotoByUserName(i.CreatedBy.UserName).PhotoBase,
                CreatedById = i.CreatedById,
            }).FirstOrDefaultAsync();


            return news;

        }
    }
}
