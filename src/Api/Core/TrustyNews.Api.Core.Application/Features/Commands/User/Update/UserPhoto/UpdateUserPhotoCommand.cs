using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Api.Core.Application.Features.Commands.User.Update.UserPhoto
{
    public class UpdateUserPhotoCommand : IRequest<Guid>
    {
        public UpdateUserPhotoCommand(IFormFile file, Guid id)
        {
            Id = id;
            File = file;
        }
        public Guid Id { get; set; }
        public IFormFile File { get; set; }

    }
}
