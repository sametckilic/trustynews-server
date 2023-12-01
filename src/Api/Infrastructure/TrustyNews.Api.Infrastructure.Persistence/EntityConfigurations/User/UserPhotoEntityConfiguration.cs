using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Api.Core.Domain.Models;
using TrustyNews.Api.Infrastructure.Persistence.Context;

namespace TrustyNews.Api.Infrastructure.Persistence.EntityConfigurations.User
{
    public class UserPhotoEntityConfiguration : BaseEntityConfiguration<UserPhoto>
    {
        public override void Configure(EntityTypeBuilder<UserPhoto> builder)
        {
            base.Configure(builder);

            builder.ToTable("userphotos", TrustyNewsContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.CreatedBy)
                   .WithOne(i => i.UserPhoto)
                   .HasForeignKey<UserPhoto>(i => i.CreatedById)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(i => i.PhotoBase).HasDefaultValue("user-photos/ifnwrbxcragwe0bdnugz");
        }
    }
}
