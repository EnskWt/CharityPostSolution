using CharityPost.Core.Domain.Entities.IdentityEntities;
using CharityPost.Core.Domain.Entities.PublicationEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CharityPost.Infrastructure.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Publication> Publications { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Publication>()
                .HasMany(p => p.Images)
                .WithOne(i => i.Publication)
                .HasForeignKey(i => i.PublicationId);

        }
    }
}
