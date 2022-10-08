using Backend.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL.DbContexts
{
    public class GamificationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Models.Task> Tasks { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<CompletedTask> CompletedTasks { get; set; }

        public DbSet<GameRole> GameRoles { get; set; }

        public GamificationDbContext(DbContextOptions<GamificationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Task>()
                .HasOne(x => x.Creator)
                .WithMany(x => x.CreatedTasks);

            modelBuilder.Entity<Models.Task>()
                .HasMany(x => x.TargetUsers)
                .WithMany(x => x.Tasks);

        }
    }
}
