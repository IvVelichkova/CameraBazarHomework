namespace CameraBazar.Data
{
    using Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class CameraBazarDbContext : IdentityDbContext<User>
    {

        public CameraBazarDbContext(DbContextOptions<CameraBazarDbContext> options)
            : base(options)
        {
        }

        public DbSet<Camera> Cameras { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(c => c.Cameras)
                .WithOne(u => u.User).
                HasForeignKey(u => u.UserId);

            base.OnModelCreating(builder);

        }
    }
}
