using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecLibras.Services.Api.Model;
using TecLibras.Services.Api.Models;

namespace TecLibras.Services.Api.Mappings
{    
    public class PointEventsMap : IEntityTypeConfiguration<PointEvent>
    {
        public void Configure(EntityTypeBuilder<PointEvent> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Points)
                .HasColumnName("Points")
                .IsRequired();

            builder.Property(c => c.DateTime)
               .HasColumnName("DateTime")
               .IsRequired();

            builder.Property(c => c.UserId)
               .HasColumnName("UserId")
               .IsRequired();

        }
    }
}
