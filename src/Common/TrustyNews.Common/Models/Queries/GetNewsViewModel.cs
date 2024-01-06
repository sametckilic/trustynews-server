using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Common.Models.Queries
{
    public class GetNewsViewModel
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string NewsCoverPhotoBase { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BookmarkedCount {  get; set; }
        public bool isBookmarked { get; set; }
    }
}
