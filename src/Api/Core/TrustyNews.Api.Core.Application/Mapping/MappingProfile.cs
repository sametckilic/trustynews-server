using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Features.Commands.User.Create;
using TrustyNews.Api.Core.Domain.Models;
using TrustyNews.Common.Models.Queries;
using TrustyNews.Common.Models.RequestModels.User.Create;

namespace TrustyNews.Api.Core.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginUserViewModel>()
                .ReverseMap();

            CreateMap<CreateUserCommand, User>();

          
        }
    }
}
