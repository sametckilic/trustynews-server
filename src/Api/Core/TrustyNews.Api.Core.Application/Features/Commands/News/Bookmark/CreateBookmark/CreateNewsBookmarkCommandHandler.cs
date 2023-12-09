using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Api.Core.Domain.Models;
using TrustyNews.Common.Exceptions;

namespace TrustyNews.Api.Core.Application.Features.Commands.News.Bookmark.CreateBookmark
{
    public class CreateNewsBookmarkCommandHandler : IRequestHandler<CreateNewsBookmarkCommand, bool>
    {
        private readonly INewsBookmarkRepository newsBookmarkRepository;
        private readonly IMapper mapper;

        public CreateNewsBookmarkCommandHandler(INewsBookmarkRepository newsBookmarkRepository, IMapper mapper)
        {
            this.newsBookmarkRepository = newsBookmarkRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(CreateNewsBookmarkCommand request, CancellationToken cancellationToken)
        {
            var existBookmarkQuery = newsBookmarkRepository.AsQueryable()
                                     .Where(i => i.CreatedById == request.CreatedById)
                                     .Where(i => i.NewsId == request.NewsId);

            var existBookmark = existBookmarkQuery.FirstOrDefault();

            if (existBookmark != null)
                throw new DatabaseValidationException("This news is aldready bookmarked!");

            var dbEntry = mapper.Map<NewsBookmark>(request);

            var addedRow = await newsBookmarkRepository.AddAsync(dbEntry);

            return true;
        }
    }
}
