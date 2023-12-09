using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Common.Exceptions;

namespace TrustyNews.Api.Core.Application.Features.Commands.News.Bookmark.DeleteBookmark
{
    public class DeleteNewsBookmarkCommandHandler : IRequestHandler<DeleteNewsBookmarkCommand, bool>
    {
        private readonly INewsBookmarkRepository newsBookmarkRepository;

        public DeleteNewsBookmarkCommandHandler(INewsBookmarkRepository newsBookmarkRepository)
        {
            this.newsBookmarkRepository = newsBookmarkRepository;
        }
        public async Task<bool> Handle(DeleteNewsBookmarkCommand request, CancellationToken cancellationToken)
        {
            var existBookmarkQuery = newsBookmarkRepository.AsQueryable()
                                    .Where(i => i.NewsId == request.NewsId)
                                    .Where(i => i.CreatedById == request.CreatedById);

            var existBookmark = existBookmarkQuery.FirstOrDefault();

            if (existBookmark == null)
                throw new DatabaseValidationException("Bookmarks not found!");

            var deletedRow = await newsBookmarkRepository.DeleteAsync(existBookmark);

            return true;
        }
    }
}
