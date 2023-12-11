using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Common.Models.Queries
{
    public class GetNewsCommentViewModel
    {
        public Guid Id {  get; set; }
        public string Content { get; set; }
        public string CreatedByUserName {  get; set; }
        public string PhotoBase {  get; set; }
        public DateTime CreateDate { get; set; }
    }
}
