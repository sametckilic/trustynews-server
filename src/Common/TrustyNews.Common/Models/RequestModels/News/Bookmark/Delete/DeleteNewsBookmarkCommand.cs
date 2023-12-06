using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Common.Models.RequestModels.News.Bookmark.Delete
{
    public class DeleteNewsBookmarkCommand : IRequest<bool>
    {
        public DeleteNewsBookmarkCommand(Guid createdById, Guid newsId)
        {
            CreatedById = createdById;
            NewsId = newsId;
        }

        public Guid CreatedById {  get; set; }  
        public Guid NewsId { get; set; }
    }
    
}
