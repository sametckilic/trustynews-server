using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Common.Models.Queries
{
    public class BaseFooterRateViewModel
    {
        public VoteType VoteType { get; set; }

    }

    public class BaseFooterBookmarkedViewModel
    {
        public bool IsBookmarked { get; set; }
        public int BookmarkedCount { get; set; }
    }

    public class BaseFooterRateBookmarkedViewModel : BaseFooterBookmarkedViewModel
    {
        public VoteType VoteType { get; set; }
    }
}
