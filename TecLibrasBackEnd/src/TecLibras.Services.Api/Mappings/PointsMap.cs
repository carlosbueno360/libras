using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecLibras.Services.Api.Models;
using TecLibras.Services.Api.Models;

namespace TecLibras.Services.Api.Mappings
{    
    public class PointsMap : IEntityTypeConfiguration<Points>
    {
        public void Configure(EntityTypeBuilder<Points> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.points)
                .HasMaxLength(100)
                .HasColumnName("Points")
                .IsRequired();

        }
    }
}
