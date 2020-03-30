using Microsoft.EntityFrameworkCore;
using TecLibras.Services.Api.Models;

namespace TecLibras.Services.Api.Context
{
    public class TecLibrasContext : DbContext
    {
        public TecLibrasContext(DbContextOptions<TecLibrasContext> options) : base(options) { }

        public DbSet<Points> Pointss { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new PointsMap());
                        
            base.OnModelCreating(modelBuilder);
        }
    }
}
