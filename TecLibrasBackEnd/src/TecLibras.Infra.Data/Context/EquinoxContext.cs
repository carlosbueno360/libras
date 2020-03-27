using TecLibras.Domain.Models;
using TecLibras.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace TecLibras.Infra.Data.Context
{
    public class TecLibrasContext : DbContext
    {
        public TecLibrasContext(DbContextOptions<TecLibrasContext> options) : base(options) { }

        public DbSet<Points> Pointss { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PointsMap());
                        
            base.OnModelCreating(modelBuilder);
        }
    }
}
