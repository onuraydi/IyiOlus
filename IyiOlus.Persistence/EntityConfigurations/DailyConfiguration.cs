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
    public class DailyConfiguration : IEntityTypeConfiguration<Daily>
    {
        public void Configure(EntityTypeBuilder<Daily> builder)
        {
            //builder.ToTable("");

            builder.Property(d => d.Title).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Content).IsRequired().HasMaxLength(2000);
            builder.Property(d => d.Date).IsRequired();

            builder.HasIndex(d => new { d.userId, d.Date }).IsUnique();

            builder.HasOne(u => u.user)
                .WithMany(d => d.Dailies)
                .HasForeignKey(u => u.userId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
