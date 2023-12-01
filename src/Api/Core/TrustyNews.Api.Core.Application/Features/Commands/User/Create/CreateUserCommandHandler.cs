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
using TrustyNews.Common.Models.RequestModels.User;

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
            var existsUser = await userRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAddress);

            if (existsUser != null)
                throw new DatabaseValidationException("This email address is already used.");

            var dbUser = mapper.Map<Domain.Models.User>(request);

            dbUser.Password = PasswordEncrypter.Encrypt(dbUser.Password);
            
            var rows = await userRepository.AddAsync(dbUser);

            var dbUserPhoto = new UserPhoto()
            {
                CreatedById = dbUser.Id,
            };

            var userPhotoRows = await userPhotoRepository.AddAsync(dbUserPhoto);

            UpdateCreatedUserPhotoToDefault(dbUser.Id, dbUserPhoto.Id);

            return dbUser.Id;
        }

        public async void UpdateCreatedUserPhotoToDefault(Guid userId, Guid photoId)
        {
            var user = await userRepository.GetByIdAsync(userId);

            user.UserPhotoId = photoId;

            var updatedRows = await userRepository.UpdateAsync(user);
        }

       
    }
}
