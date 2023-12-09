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

namespace TrustyNews.Api.Core.Application.Features.Commands.News.Tag.CreateTag
{
    public class CreateNewsTagCommandHandler : IRequestHandler<CreateNewsTagCommand, Guid>
    {
        private readonly INewsTagRepository newsTagRepository;
        private readonly IMapper mapper;

        public CreateNewsTagCommandHandler(INewsTagRepository newsTagRepository, IMapper mapper)
        {
            this.newsTagRepository = newsTagRepository;
            this.mapper = mapper;
        }

        public async Task<Guid> Handle(CreateNewsTagCommand request, CancellationToken cancellationToken)
        {
            var existTagQuery = newsTagRepository.AsQueryable()
                                .Where(i => i.TagName == request.TagName)
                                .Where(i => i.NewsId == request.NewsId);

            var existTag = existTagQuery.FirstOrDefault();

            if (existTag != null)
                throw new DatabaseValidationException("This news already has this tag!");
            
            var dbEntry = mapper.Map<NewsTag>(request);

            var addedRow = await newsTagRepository.AddAsync(dbEntry);

            return dbEntry.Id;
        }
    }
}
