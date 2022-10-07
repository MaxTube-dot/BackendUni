using Backend.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAL.DbContexts
{
    public class GamificationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public GamificationDbContext(DbContextOptions<GamificationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
