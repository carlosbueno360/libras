using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecLibras.Domain.Models;

namespace TecLibras.Infra.Data.Mappings
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
