using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Common.Exceptions;
using TrustyNews.Common.Infrastructure;

namespace TrustyNews.Api.Core.Application.Features.Commands.User.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public ChangePasswordCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await userRepository.GetByIdAsync(request.Id);

            if (dbUser == null)
                throw new DatabaseValidationException("User not found!");

            var oldPasswordRequest = PasswordEncrypter.Encrypt(request.OldPassword);

            var newPasswordRequest = PasswordEncrypter.Encrypt(request.NewPassword);

            if (dbUser.Password != oldPasswordRequest)
                throw new DatabaseValidationException("Old Password don't match with user's password!");

            dbUser.Password = newPasswordRequest;

            await userRepository.UpdateAsync(dbUser);

            return true;
        }
    }
}
