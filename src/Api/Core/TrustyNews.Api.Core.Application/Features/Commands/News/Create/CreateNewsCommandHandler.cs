using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Api.Core.Domain.Models;
using TrustyNews.Common.Models.RequestModels.News.Create;

namespace TrustyNews.Api.Core.Application.Features.Commands.News.Create
{
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly INewsRepository newsRepository;
        private readonly INewsCoverPhotoRepository newsCoverPhotoRepository;

        public CreateNewsCommandHandler(IMapper mapper, INewsRepository newsRepository, INewsCoverPhotoRepository newsCoverPhotoRepository)
        {
            this.mapper = mapper;
            this.newsRepository = newsRepository;
            this.newsCoverPhotoRepository = newsCoverPhotoRepository;
        }

        public async Task<Guid> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {

            var dbEntry = mapper.Map<Domain.Models.News>(request);

            await newsRepository.AddAsync(dbEntry);

            var newsCoverPhoto = new NewsCoverPhoto()
            {
                CreatedById = dbEntry.CreatedById,
                NewsId = dbEntry.Id
            };

            await newsCoverPhotoRepository.AddAsync(newsCoverPhoto);

            var news = await newsRepository.GetByIdAsync(dbEntry.Id);

            news.NewsCoverPhotoId = newsCoverPhoto.Id;

            await newsRepository.UpdateAsync(news);

            return dbEntry.Id;
        }
    }
}
