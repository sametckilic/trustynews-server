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
using TrustyNews.Common.Infrastructure;
using TrustyNews.Common.Models.RequestModels.User.Create;

namespace TrustyNews.Api.Core.Application.Features.Commands.User.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly IUserPhotoRepository userPhotoRepository;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository, IUserPhotoRepository userPhotoRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.userPhotoRepository = userPhotoRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            
            var existsUserEmailAddress = await userRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAddress);
            if (existsUserEmailAddress != null)
                throw new DatabaseValidationException("This email address is already used.");

            // TODO numara kontrol
            //var existsPhoneNumber = await userRepository.GetSingleAsync(i => i.PhoneNumber == request.PhoneNumber);
            //if (existsPhoneNumber != null)
            //    throw new DatabaseValidationException("This phone number is already used.");

            var dbUser = mapper.Map<Domain.Models.User>(request);

            dbUser.Password = PasswordEncrypter.Encrypt(dbUser.Password);
            
            var rows = await userRepository.AddAsync(dbUser);

            var dbUserPhoto = new UserPhoto()
            {
                CreatedById = dbUser.Id,
            };

            var userPhotoRows = await userPhotoRepository.AddAsync(dbUserPhoto);

            var user = await userRepository.GetByIdAsync(dbUser.Id);

            user.UserPhotoId = dbUserPhoto.Id;

            var updatedRows = await userRepository.UpdateAsync(user);



            return dbUser.Id;
        }

       
    }
}
