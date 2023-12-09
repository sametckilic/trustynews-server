using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Common.Models.Queries
{
    public class GetNewsDetailViewModel : BaseFooterRateBookmarkedViewModel
    {
        public Guid Id { get; set; }
        public string Subject {  get; set; }
        public string Content {  get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserName {  get; set; }
        public string NewsCoverPhotoBase { get; set; }
    }
}
