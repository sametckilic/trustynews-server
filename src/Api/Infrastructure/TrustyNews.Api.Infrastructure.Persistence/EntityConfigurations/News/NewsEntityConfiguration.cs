using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Domain.Models;
using TrustyNews.Api.Infrastructure.Persistence.Context;

namespace TrustyNews.Api.Infrastructure.Persistence.EntityConfigurations.News
{
    public class NewsEntityConfiguration : BaseEntityConfiguration<Core.Domain.Models.News>
    {
        public override void Configure(EntityTypeBuilder<Core.Domain.Models.News> builder)
        {
            base.Configure(builder);

            builder.ToTable("news", TrustyNewsContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.CreatedBy)
                    .WithMany(i => i.News)
                    .HasForeignKey(i => i.CreatedById)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.NewsCoverPhoto)
                  .WithOne(i => i.News)
                  .HasForeignKey<NewsCoverPhoto>(i => i.NewsId);


        }
    }
}
