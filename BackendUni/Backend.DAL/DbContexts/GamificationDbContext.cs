using Backend.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL.DbContexts
{
    public class GamificationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public GamificationDbContext(DbContextOptions<GamificationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
