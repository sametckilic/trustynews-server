using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Api.Core.Domain.Models;
using TrustyNews.Api.Infrastructure.Persistence.Context;

namespace TrustyNews.Api.Infrastructure.Persistence.Repositories.User
{
    public class UserPhotoRepository : GenericRepository<UserPhoto>, IUserPhotoRepository
    {
        public UserPhotoRepository(TrustyNewsContext dbContext) : base(dbContext)
        {
            
        }

        public virtual UserPhoto GetUserPhotoByUserName(string userName)
        {
            var userPhoto = Get(i => i.CreatedBy.UserName == userName).FirstOrDefault();

            return userPhoto;
        }
    }
}
