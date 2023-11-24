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
    public class NewsCommentEntityConfiguration : BaseEntityConfiguration<NewsComment>
    {
        public override void Configure(EntityTypeBuilder<NewsComment> builder)
        {
            base.Configure(builder);

            builder.ToTable("newscomments", TrustyNewsContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.News)
                .WithMany(i => i.NewsComments)
                .HasForeignKey(i => i.NewsId);

            builder.HasOne(i => i.CreatedBy)
                .WithMany(i => i.NewsComments)
                .HasForeignKey(i => i.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
