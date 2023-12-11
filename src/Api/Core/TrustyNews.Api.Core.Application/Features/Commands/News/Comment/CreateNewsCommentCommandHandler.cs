using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Api.Core.Domain.Models;

namespace TrustyNews.Api.Core.Application.Features.Commands.News.Comment
{
    public class CreateNewsCommentCommandHandler : IRequestHandler<CreateNewsCommentCommand, NewsComment>
    {
        private readonly INewsCommentRepository newsCommentRepository;
        private readonly IMapper mapper;

        public CreateNewsCommentCommandHandler(INewsCommentRepository newsCommentRepository, IMapper mapper)
        {
            this.newsCommentRepository = newsCommentRepository;
            this.mapper = mapper;
        }

        public async Task<NewsComment> Handle(CreateNewsCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = mapper.Map<NewsComment>(request);

            await newsCommentRepository.AddAsync(comment);

            return comment;
        }

        //TODO delete comment ekle
    }
}
