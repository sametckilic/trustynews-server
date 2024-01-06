using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Features.Commands.News.Bookmark.CreateBookmark;
using TrustyNews.Api.Core.Application.Features.Commands.News.Comment.Create;
using TrustyNews.Api.Core.Application.Features.Commands.News.Create;
using TrustyNews.Api.Core.Application.Features.Commands.News.Tag.CreateTag;
using TrustyNews.Api.Core.Application.Features.Commands.News.Vote.CreateVote;
using TrustyNews.Api.Core.Application.Features.Commands.User.Create;
using TrustyNews.Api.Core.Domain.Models;
using TrustyNews.Common.Models.Queries;


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

            CreateMap<CreateNewsCommentCommand, NewsComment>();

            CreateMap<CreateNewsVoteCommand, NewsVote>();

            CreateMap<CreateNewsBookmarkCommand, NewsBookmark>();

            CreateMap<CreateNewsTagCommand, NewsTag>();

            CreateMap<News, GetNewsViewModel>()
                .ForMember(x => x.BookmarkedCount, y => y.MapFrom(z => z.NewsBookmarks.Count));
        }
    }
}
