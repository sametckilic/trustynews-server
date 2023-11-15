using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Api.Core.Domain.Models
{
    public class UserPhoto : BaseEntity
    {
        public string PhotoBase { get; set; }
        public Guid CreatedById { get; set; }

        public virtual User CreatedBy { get; set; }

    }
}
