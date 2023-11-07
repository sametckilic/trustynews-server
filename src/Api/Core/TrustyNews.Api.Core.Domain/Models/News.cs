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
        public virtual User CreatedBy { get; set; }

    }
}
