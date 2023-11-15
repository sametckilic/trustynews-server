using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Api.Core.Domain.Models
{
    public class NewsComment : BaseEntity
    {
        public string Content { get; set; }
        public Guid CreatedById { get; set; }
        public Guid NewsId { get; set; }
        public virtual News News { get; set; }
        public virtual User CreatedBy { get; set; }

    }
}
