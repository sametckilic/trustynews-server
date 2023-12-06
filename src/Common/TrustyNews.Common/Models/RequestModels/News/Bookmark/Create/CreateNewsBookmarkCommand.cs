using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Common.Models.RequestModels.News.Bookmark.Create
{
    public class CreateNewsBookmarkCommand : IRequest<bool>
    {
        public CreateNewsBookmarkCommand(Guid newsId, Guid createdById)
        {
            NewsId = newsId;
            CreatedById = createdById;
        }

        public Guid NewsId { get; set; }
        public Guid CreatedById { get; set; }
    }
}
