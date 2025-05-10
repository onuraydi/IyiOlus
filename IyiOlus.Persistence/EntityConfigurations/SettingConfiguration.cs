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
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            //builder.ToTable("");

            builder.Property(s => s.NotificationTime).IsRequired().HasDefaultValue(new TimeSpan(12,0,0));

            builder.Property(s => s.isActive).IsRequired();

            builder.HasOne(u => u.User)
                .WithOne(s => s.Setting)
                .HasForeignKey<Setting>(u => u.UserId)  // bu kısımda değişiklik gerekebilir.
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
