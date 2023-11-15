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
        public virtual User CreatedBy { get; set; }
        public virtual NewsCoverPhoto NewsCoverPhoto { get; set; }


        public virtual ICollection<NewsVote> NewsVote { get; set; }
        public virtual ICollection<NewsComment> NewsComment { get; set; }
        public virtual ICollection<NewsTag> NewsTag { get; set; }


    }
}
