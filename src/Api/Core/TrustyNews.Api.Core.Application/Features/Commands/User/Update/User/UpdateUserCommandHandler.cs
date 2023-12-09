using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Common.Exceptions;

namespace TrustyNews.Api.Core.Application.Features.Commands.User.Update.User
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await userRepository.GetByIdAsync(request.Id);

            if (dbUser == null)
                throw new DatabaseValidationException("User not found!");

            var emailExist = userRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAddress);

            if (emailExist != null)
                throw new DatabaseValidationException("This email address is already used.");

            var phoneNumberExists = userRepository.GetSingleAsync(i => i.PhoneNumber == request.PhoneNumber);
            
            if(phoneNumberExists != null)    
                throw new DatabaseValidationException("This phone number is already used.");

            if (dbUser.PhoneNumber != request.PhoneNumber)
                dbUser.IsPhoneConfirmed = false;

            if (dbUser.EmailAddress!= request.EmailAddress)
                dbUser.IsEmailConfirmed = false;

            mapper.Map(request, dbUser);

            var rows = await userRepository.UpdateAsync(dbUser);

            return dbUser.Id;

            
        }
    }
}
