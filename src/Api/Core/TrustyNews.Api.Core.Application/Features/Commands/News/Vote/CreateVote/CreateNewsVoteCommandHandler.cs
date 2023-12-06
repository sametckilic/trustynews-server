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
using TrustyNews.Common.Models.RequestModels.News.Vote.Create;

namespace TrustyNews.Api.Core.Application.Features.Commands.News.Vote.CreateVote
{
    public class CreateNewsVoteCommandHandler : IRequestHandler<CreateNewsVoteCommand, bool>
    {
        private readonly IMapper mapper;
        private readonly INewsVoteRepository newsVoteRepository;

        public CreateNewsVoteCommandHandler(IMapper mapper, INewsVoteRepository newsVoteRepository)
        {
            this.mapper = mapper;
            this.newsVoteRepository = newsVoteRepository;
        }

        public async Task<bool> Handle(CreateNewsVoteCommand request, CancellationToken cancellationToken)
        {
            var existVoteQuery = newsVoteRepository.AsQueryable()
                .Where(i => i.CreatedById == request.CreatedById)
                .Where(i => i.NewsId == request.NewsId);

            var existVote = existVoteQuery.FirstOrDefault();

            if(existVote != null){
                existVote.VoteType = request.VoteType;
                await newsVoteRepository.UpdateAsync(existVote);
                return true;
            }
            
            var dbEntry = mapper.Map<NewsVote>(request);

            var rows = await newsVoteRepository.AddAsync(dbEntry);

            return true;
        }
    }
}
