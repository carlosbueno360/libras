using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TecLibras.Services.Api.Mappings;
using TecLibras.Services.Api.Model;

namespace TecLibras.Services.Api.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PointEvent> PointEvents { get; set; }

        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
                            .ToTable("ApplicationUser");

            modelBuilder.ApplyConfiguration(new PointEventsMap());
            modelBuilder.ApplyConfiguration(new QuestionMap());
            modelBuilder.ApplyConfiguration(new RankMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
