using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Common.Exceptions;
using TrustyNews.Common.Models.RequestModels.News.Vote.Delete;

namespace TrustyNews.Api.Core.Application.Features.Commands.News.Vote.DeleteVote
{
    public class DeleteNewsVoteCommandHandler : IRequestHandler<DeleteNewsVoteCommand, bool>
    {
        private readonly INewsVoteRepository newsVoteRepository;

        public DeleteNewsVoteCommandHandler(INewsVoteRepository newsVoteRepository)
        {
            this.newsVoteRepository = newsVoteRepository;
        }

        public async Task<bool> Handle(DeleteNewsVoteCommand request, CancellationToken cancellationToken)
        {
            var dbEntryQuery = newsVoteRepository.AsQueryable()
                          .Where(i => i.NewsId == request.NewsId)
                          .Where(i => i.CreatedById == request.CreatedById);

            var dbEntry = dbEntryQuery.FirstOrDefault();

            if (dbEntry == null)
                throw new DatabaseValidationException("Vote does not exist!");

            var deletedRows = await newsVoteRepository.DeleteAsync(dbEntry);

            return true;
        }
    }
}
