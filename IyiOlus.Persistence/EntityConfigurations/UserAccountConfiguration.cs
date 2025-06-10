using IyiOlus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Persistence.EntityConfigurations
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccountInfo>
    {
        public void Configure(EntityTypeBuilder<UserAccountInfo> builder)
        {
            //builder.ToTable("UserAccountInfo");

            builder.Property(ua => ua.Email).IsRequired().HasMaxLength(50);
            builder.HasIndex(ua => ua.Email).IsUnique();

            builder.Property(ua => ua.Password).IsRequired().HasMaxLength(50);
            builder.Property(ua => ua.Status).IsRequired().HasDefaultValue(true);
            builder.Property(ua => ua.isVerification).IsRequired().HasDefaultValue(false);

            builder.HasOne(u => u.User)
                .WithOne(ua => ua.UserAccountInfo)
                .HasForeignKey<User>(u => u.UserAccountInfoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
