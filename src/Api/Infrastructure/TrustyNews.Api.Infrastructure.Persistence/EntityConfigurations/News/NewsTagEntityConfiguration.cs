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
    public class NewsTagEntityConfiguration : BaseEntityConfiguration<NewsTag>
    {
        public override void Configure(EntityTypeBuilder<NewsTag> builder)
        {
            base.Configure(builder);

            builder.ToTable("newstags", TrustyNewsContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.News)
                    .WithMany(i => i.NewsTags)
                    .HasForeignKey(i => i.NewsId);

            builder.HasOne(i => i.CreatedBy)
                .WithMany(i => i.NewsTags)
                .HasForeignKey(i => i.CreatedById);
        }
    }
}
