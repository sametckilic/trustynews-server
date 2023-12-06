using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Api.Core.Domain.Models
{
    public class NewsTag : BaseEntity
    {
        public Guid NewsId { get; set; }
        public string TagName { get; set; }
        public Guid CreatedById {  get; set; }
        public virtual News News{ get; set; }
        public virtual User CreatedBy { get; set; }
    }
}
