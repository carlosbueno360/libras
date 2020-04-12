using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecLibras.Services.Api.Model;
using TecLibras.Services.Api.Models;

namespace TecLibras.Services.Api.Mappings
{
    public class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Points)
                .HasColumnName("Points")
                .IsRequired();

            builder.Property(c => c.Level)
               .HasColumnName("Level")
               .IsRequired();

            builder.Property(c => c.Awnser)
               .HasColumnName("Awnser")
               .IsRequired();

            builder.Property(c => c.Title)
               .HasColumnName("Question")
               .IsRequired();

        }
    }
}
