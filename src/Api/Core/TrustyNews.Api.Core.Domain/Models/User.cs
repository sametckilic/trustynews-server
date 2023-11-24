using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustyNews.Api.Core.Domain.Models
{
    public class User : BaseEntity
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsPhoneConfirmed { get; set; }
        public bool IsConfirmedUser {  get; set; }
        public bool IsTrustedUser {  get; set; }
        public Guid UserPhotoId { get; set; }

        public virtual UserPhoto UserPhoto { get; set; }

        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<NewsComment> NewsComments { get; set; }
        public virtual ICollection<NewsBookmark> NewsBookmarks { get; set; }    
        public virtual ICollection<NewsCoverPhoto> NewsCoverPhotos { get; set;}
        public virtual ICollection<NewsVote> NewsVotes { get; set; }

    }
}
