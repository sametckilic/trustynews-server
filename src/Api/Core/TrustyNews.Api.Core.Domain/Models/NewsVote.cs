using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Common.Models;

namespace TrustyNews.Api.Core.Domain.Models
{
    public class NewsVote : BaseEntity
    {
        public Guid NewsId {  get; set; }
        public VoteType VoteType { get; set; }
        public Guid CreatedById {  get; set; }

        public virtual News News { get; set; }
    }
}
