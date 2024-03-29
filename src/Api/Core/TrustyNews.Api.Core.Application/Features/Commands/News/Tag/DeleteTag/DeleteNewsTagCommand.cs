﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Api.Core.Application.Features.Commands.News.Tag.DeleteTag
{
    public class DeleteNewsTagCommand : IRequest<bool>
    {
        public DeleteNewsTagCommand(Guid id, Guid createdById)
        {
            Id = id;
            CreatedById = createdById;
        }

        public Guid Id { get; set; }
        public Guid CreatedById { get; set; }
    }
}
