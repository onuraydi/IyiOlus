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
    public class DailyMoodConfiguration : IEntityTypeConfiguration<DailyMood>
    {
        public void Configure(EntityTypeBuilder<DailyMood> builder)
        {
            builder.Property(d => d.Mood)
                .IsRequired();

            builder.Property(d => d.Date)
                .HasColumnType("date")
                .IsRequired();

            builder.HasIndex(d => new { d.UserId, d.Date })
                .IsUnique();

            builder.HasOne(d => d.User)
                .WithMany(u => u.DailyMoods)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
