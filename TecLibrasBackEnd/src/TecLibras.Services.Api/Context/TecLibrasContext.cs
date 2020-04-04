using Microsoft.EntityFrameworkCore;
using TecLibras.Services.Api.Mappings;
using TecLibras.Services.Api.Model;
using TecLibras.Services.Api.Models;

namespace TecLibras.Services.Api.Context
{
    public class TecLibrasContext : DbContext
    {
        public TecLibrasContext(DbContextOptions<TecLibrasContext> options) : base(options) { }

        public DbSet<PointEvent> PointEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PointEventsMap());
                        
            base.OnModelCreating(modelBuilder);
        }
    }
}
