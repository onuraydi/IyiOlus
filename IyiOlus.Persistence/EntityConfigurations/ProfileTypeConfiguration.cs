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
    public class ProfileTypeConfiguration : IEntityTypeConfiguration<ProfileType>
    {
        public void Configure(EntityTypeBuilder<ProfileType> builder)
        {
            //builder.ToTable("");

            builder.Property(p => p.Type).IsRequired();

            builder.HasMany(q => q.Questions)
                .WithOne(p => p.ProfileType)
                .HasForeignKey(p => p.ProfileTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
