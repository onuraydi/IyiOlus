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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.ToTable("Users");

            builder.Property(u => u.Name).IsRequired().HasMaxLength(30);
            builder.Property(u => u.Surname).IsRequired().HasMaxLength(30);
            builder.Property(u => u.DateOfBirth).IsRequired().HasColumnType("date");
            builder.Property(u => u.WorkState).IsRequired();
            builder.Property(u => u.EducationLevel).IsRequired();
            builder.Property(u => u.Gender).IsRequired();
            builder.Property(u => u.Relation).IsRequired();

            // ilişkiler gerekirse burada da ayarlanacak
            builder.HasOne(ua => ua.ApplicationUser)
                .WithOne(u => u.User)
                .HasForeignKey<User>(u => u.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Exercises)
                .WithOne(u => u.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
