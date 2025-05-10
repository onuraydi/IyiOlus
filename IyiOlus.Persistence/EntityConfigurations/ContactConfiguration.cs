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
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            //builder.ToTable("ads");

            builder.Property(c => c.Subject).IsRequired().HasMaxLength(200);

            builder.Property(c => c.Message).IsRequired().HasMaxLength(1000);

            builder.Property(c => c.isRead).IsRequired();

            builder.HasOne(u => u.User)
                .WithMany(c => c.Contacts)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
