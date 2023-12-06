using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Common.Exceptions;
using TrustyNews.Common.Models.RequestModels.News.Tag.Create;

namespace TrustyNews.Api.Core.Application.Features.Commands.News.Tag.DeleteTag
{
    public class DeleteNewsTagCommandHandler : IRequestHandler<DeleteNewsTagCommand, bool>
    {
        private readonly INewsTagRepository newsTagRepository;

        public DeleteNewsTagCommandHandler(INewsTagRepository newsTagRepository)
        {
            this.newsTagRepository = newsTagRepository;
        }

        public async Task<bool> Handle(DeleteNewsTagCommand request, CancellationToken cancellationToken)
        {
            var existEntry = await newsTagRepository.GetByIdAsync(request.Id);

            if (existEntry == null)
                throw new DatabaseValidationException("Tag not found!");

            await newsTagRepository.DeleteAsync(request.Id);

            return true;
        }
    }
}
