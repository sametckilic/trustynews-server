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
    public class NewsBookmarkEntityConfiguration : BaseEntityConfiguration<NewsBookmark>
    {
        public override void Configure(EntityTypeBuilder<NewsBookmark> builder)
        {
            base.Configure(builder);

            builder.ToTable("newsbookmarks", TrustyNewsContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.News)
                    .WithMany(i => i.NewsBookmarks)
                    .HasForeignKey(i => i.NewsId);

            builder.HasOne(i => i.CreatedUser)
                    .WithMany(i => i.NewsBookmarks)
                    .HasForeignKey(i => i.CreatedById)
                    .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
