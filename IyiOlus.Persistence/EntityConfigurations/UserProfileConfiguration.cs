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
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            //builder.ToTable("UserProfiles");

            builder.Property(up => up.Profile).IsRequired();
            builder.Property(up => up.State).IsRequired();
            builder.Property(up => up.ProfileTestDate).IsRequired().HasColumnType("date");


            builder.HasIndex(up => new { up.UserId, up.ProfileTypeId }).IsUnique();
            builder.HasIndex(up => new { up.ProfileTestDate, up.Id }).IsUnique();

            builder.HasOne(u => u.User)
                .WithMany(up => up.UserProfiles)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pt => pt.ProfileType)
                .WithMany(up => up.UserProfiles)
                .HasForeignKey(pt => pt.ProfileTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
