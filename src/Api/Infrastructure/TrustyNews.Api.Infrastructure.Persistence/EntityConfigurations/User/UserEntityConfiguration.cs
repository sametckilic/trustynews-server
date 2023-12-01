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
    public class UserEntityConfiguration : BaseEntityConfiguration<Core.Domain.Models.User>
    {
        public override void Configure(EntityTypeBuilder<Core.Domain.Models.User> builder)
        {
            base.Configure(builder);

            builder.ToTable("users", TrustyNewsContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.UserPhoto)
                   .WithOne(i => i.CreatedBy)
                   .HasForeignKey<Core.Domain.Models.User>(i => i.UserPhotoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(i => i.IsTrustedUser).HasDefaultValue(false);
            builder.Property(i => i.IsConfirmedUser).HasDefaultValue(false);
            builder.Property(i => i.IsPhoneConfirmed).HasDefaultValue(false);
            builder.Property(i => i.IsEmailConfirmed).HasDefaultValue(false);


        }

    }
}
