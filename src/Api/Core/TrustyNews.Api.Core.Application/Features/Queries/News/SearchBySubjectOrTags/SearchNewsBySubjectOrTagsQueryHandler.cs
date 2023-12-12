using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Common.Models.Queries;

namespace TrustyNews.Api.Core.Application.Features.Queries.News.SearchBySubjectOrTags
{
    public class SearchNewsBySubjectOrTagsQueryHandler : IRequestHandler<SearchNewsBySubjectOrTagsQuery, List<SearchNewsViewModel>>
    {
        private readonly INewsRepository newsRepository;
        private readonly INewsTagRepository newsTagRepository;

        public SearchNewsBySubjectOrTagsQueryHandler(INewsRepository newsRepository, INewsTagRepository newsTagRepository)
        {
            this.newsTagRepository = newsTagRepository;
            this.newsRepository = newsRepository;
        }

        public async Task<List<SearchNewsViewModel>> Handle(SearchNewsBySubjectOrTagsQuery request, CancellationToken cancellationToken)
        {
            var resultBySubject = await newsRepository
                .Get(i => EF.Functions.Like(i.Subject, $"%{request.SearchText}%"))
                .Select(i => new SearchNewsViewModel()
                {
                    Id = i.Id,
                    Subject = i.Subject
                }).ToListAsync(cancellationToken);

            var resultQueryForTags = newsTagRepository.AsQueryable();

            resultQueryForTags = resultQueryForTags.Include(i => i.News)
                .Where(i => i.TagName == request.SearchText);


            var resultByTag = await resultQueryForTags.Select(i => new SearchNewsViewModel()
            {
                Id = i.News.Id,
                Subject = i.News.Subject
            }).ToListAsync(cancellationToken);

            if (resultBySubject.Count == 0)
                return  resultByTag;
            else if (resultByTag.Count == 0)
                return resultBySubject;
            else
                return null;
        }
    }
}
