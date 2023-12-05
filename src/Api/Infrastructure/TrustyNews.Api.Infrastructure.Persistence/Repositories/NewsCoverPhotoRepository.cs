using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Api.Core.Domain.Models;

namespace TrustyNews.Api.Infrastructure.Persistence.Repositories
{
    public class NewsCoverPhotoRepository : GenericRepository<NewsCoverPhoto>, INewsCoverPhotoRepository
    {
        public NewsCoverPhotoRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
