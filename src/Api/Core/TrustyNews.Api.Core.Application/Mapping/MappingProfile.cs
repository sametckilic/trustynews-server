using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Features.Commands.User.Create;
using TrustyNews.Api.Core.Domain.Models;
using TrustyNews.Common.Models.Queries;
using TrustyNews.Common.Models.RequestModels.News.Bookmark.Create;
using TrustyNews.Common.Models.RequestModels.News.Create;
using TrustyNews.Common.Models.RequestModels.News.Tag.Create;
using TrustyNews.Common.Models.RequestModels.News.Vote.Create;
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

            CreateMap<CreateNewsCommand, News>();

            CreateMap<CreateNewsVoteCommand, NewsVote>();

            CreateMap<CreateNewsBookmarkCommand, NewsBookmark>();

            CreateMap<CreateNewsTagCommand, NewsTag>();

          
        }
    }
}
