using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Common.Models.Queries;

namespace TrustyNews.Api.Core.Application.Features.Queries.News.GetNews
{
    public class GetNewsQueryHandler : IRequestHandler<GetNewsQuery, List<GetNewsViewModel>>
    {
        private readonly INewsRepository newsRepository;
        private readonly IMapper mapper;

        public GetNewsQueryHandler(INewsRepository newsRepository, IMapper mapper)
        {
            this.newsRepository = newsRepository;
            this.mapper = mapper;
        }

        public async Task<List<GetNewsViewModel>> Handle(GetNewsQuery request, CancellationToken cancellationToken)
        {
            var query = newsRepository.AsQueryable();

            if (request.TodaysNews)
            {
                query = query.Where(i => i.CreateDate > DateTime.Now.Date)
                             .Where(i => i.CreateDate <= DateTime.Now.AddDays(1));
            }

            query = query.OrderBy(i => Guid.NewGuid())
                          .Take(request.Count);

            return await query.ProjectTo<GetNewsViewModel>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
