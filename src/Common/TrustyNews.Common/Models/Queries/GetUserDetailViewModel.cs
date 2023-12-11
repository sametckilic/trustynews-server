using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Common.Models.Queries
{
    public class GetUserDetailViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
        public string PhotoBase {  get; set; }
        public string EmailAddress { get; set; }

        public bool IsTrustedUser { get; set; }
    }
}
