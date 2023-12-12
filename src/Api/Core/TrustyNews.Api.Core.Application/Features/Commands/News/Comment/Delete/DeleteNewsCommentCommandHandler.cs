using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Common.Exceptions;

namespace TrustyNews.Api.Core.Application.Features.Commands.News.Comment.Delete
{
    public class DeleteNewsCommentCommandHandler : IRequestHandler<DeleteNewsCommentCommand, bool>
    {
        private readonly INewsCommentRepository newsCommentRepository;

        public DeleteNewsCommentCommandHandler(INewsCommentRepository newsCommentRepository)
        {
            this.newsCommentRepository = newsCommentRepository;
        }

        public async Task<bool> Handle(DeleteNewsCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await newsCommentRepository.GetByIdAsync(request.Id);

            if (comment == null)
                throw new DatabaseValidationException("Comment not found!");
       
            var rows = await newsCommentRepository.DeleteAsync(comment);

            return true;
        }
    }
}
