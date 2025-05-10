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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            //builder.ToTable("");

            builder.Property(q => q.QuestionType).IsRequired();
            builder.Property(q => q.ProfileQuestion).IsRequired().HasMaxLength(100);

            builder.HasOne(p => p.ProfileType)
                .WithMany(q => q.Questions)
                .HasForeignKey(p => p.ProfileTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
