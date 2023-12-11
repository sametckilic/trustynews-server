using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Common.Exceptions;
using TrustyNews.Common.Models.Queries;

namespace TrustyNews.Api.Core.Application.Features.Queries.User.GetUserDetail
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, GetUserDetailViewModel>
    {
        private readonly IUserRepository userRepository;

        public GetUserDetailQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<GetUserDetailViewModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var query = userRepository.AsQueryable();

            query = query.Include(i => i.UserPhoto)
                    .Where(i => i.Id == request.UserId);

            var user = query.Select(i => new GetUserDetailViewModel()
            {
                Id = i.Id,
                CreateDate = i.CreateDate,
                FirstName = i.FirstName,
                LastName = i.LastName,
                UserName = i.UserName,
                PhotoBase = i.UserPhoto.PhotoBase,
                EmailAddress = i.EmailAddress,
                IsTrustedUser = i.IsTrustedUser

            }).FirstOrDefault();

            if (query == null)
                throw new DatabaseValidationException("User not found!");

            return Task.FromResult(user);
        }
    }
}
