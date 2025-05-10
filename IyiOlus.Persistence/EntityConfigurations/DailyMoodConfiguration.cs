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
            //builder.ToTable("");

            builder.Property(d => d.Mood).IsRequired();
            builder.Property(d => d.Date).IsRequired();
            
            // budara date ve userId değeri uniqe olacak yani kullanıcı aynı tarihte birden fazla duygu giremeyecek
            builder.HasIndex(d => new { d.UserId, d.Date.Date }).IsUnique(); 
            
            builder.HasOne(u => u.User)
                .WithMany(d => d.DailyMoods)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
