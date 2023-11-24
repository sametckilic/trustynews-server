using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Api.Core.Domain.Models
{
    public class News : BaseEntity
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public Guid CreatedById { get; set; }
        public bool IsTrusty { get; set; }
        public Guid NewsCoverPhotoId { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual NewsCoverPhoto NewsCoverPhoto { get; set; }


        public virtual ICollection<NewsVote> NewsVotes { get; set; }
        public virtual ICollection<NewsComment> NewsComments { get; set; }
        public virtual ICollection<NewsTag> NewsTags { get; set; }
        public virtual ICollection<NewsBookmark> NewsBookmarks { get; set; }



    }
}
