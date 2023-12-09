using CloudinaryDotNet.Actions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Extensions;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Api.Core.Domain.Models;
using TrustyNews.Common.Exceptions;

namespace TrustyNews.Api.Core.Application.Features.Commands.User.Update.UserPhoto
{
    public class UpdateUserPhotoCommandHandler : IRequestHandler<UpdateUserPhotoCommand, Guid>
    {
        private readonly IUserPhotoRepository userPhotoRepository;
        private readonly IUserRepository userRepository;
        public UpdateUserPhotoCommandHandler(IUserPhotoRepository userPhotoRepository, IUserRepository userRepository)
        {
            this.userPhotoRepository = userPhotoRepository;
            this.userRepository = userRepository;
        }

        public async Task<Guid> Handle(UpdateUserPhotoCommand request, CancellationToken cancellationToken)
        {
            UploadPhoto uploadPhoto = new UploadPhoto();
            //var user = await userRepository.GetByIdAsync(request.UserId);
            //if (user == null)
            //    throw new DatabaseValidationException("User not found!");

            var file = request.File;

            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new CloudinaryDotNet.FileDescription(file.Name, stream)
                    };

                    uploadPhoto.cloudinary.Upload(uploadParams);

                }
            }

            var userPhoto = new Domain.Models.UserPhoto()
            {
                PhotoBase = uploadResult.PublicId
            };


            return userPhoto.Id;
        }
    }
}
