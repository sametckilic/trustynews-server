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
    public class NewsCoverPhotoEntityConfiguration : BaseEntityConfiguration<NewsCoverPhoto>
    {
        public override void Configure(EntityTypeBuilder<NewsCoverPhoto> builder)
        {
            base.Configure(builder);

            builder.ToTable("newscoverphotos", TrustyNewsContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.News)
                .WithOne(i => i.NewsCoverPhoto)
                .HasForeignKey<NewsCoverPhoto>(i => i.NewsId);

            builder.HasOne(i => i.CreatedBy)
                    .WithMany(i => i.NewsCoverPhotos)
                    .HasForeignKey(i => i.CreatedById);

        }
    }
}
