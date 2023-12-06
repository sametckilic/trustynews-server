using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Application.Interfaces.Repositories;
using TrustyNews.Api.Core.Domain.Models;
using TrustyNews.Api.Infrastructure.Persistence.Context;

namespace TrustyNews.Api.Infrastructure.Persistence.Repositories.News
{
    public class NewsCoverPhotoRepository : GenericRepository<NewsCoverPhoto>, INewsCoverPhotoRepository
    {
        public NewsCoverPhotoRepository(TrustyNewsContext dbContext) : base(dbContext)
        {
        }
    }
}
