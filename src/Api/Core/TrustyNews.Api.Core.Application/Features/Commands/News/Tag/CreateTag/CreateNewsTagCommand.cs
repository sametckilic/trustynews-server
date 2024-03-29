﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Api.Core.Application.Features.Commands.News.Tag.CreateTag
{
    public class CreateNewsTagCommand : IRequest<Guid>
    {
        public CreateNewsTagCommand(Guid newsId, string tagName, Guid createdById)
        {
            NewsId = newsId;
            TagName = tagName;
            CreatedById = createdById;
        }

        public Guid NewsId { get; set; }
        public string TagName { get; set; }
        public Guid CreatedById { get; set; }
    }
}
