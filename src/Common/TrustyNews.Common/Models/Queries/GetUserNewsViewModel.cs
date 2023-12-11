using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Common.Models.Queries
{
    public class GetUserNewsViewModel
    {
        public Guid Id {  get; set; }
        public string Subject {  get; set; }
        public bool IsTrusty {  get; set; }
        public string PhotoBase {  get; set; }
        public DateTime CreateDate {  get; set; }
        public int BookmarkedCount { get; set; }

    }
}
