using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Common.Models.RequestModels.News.Tag.Create
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
