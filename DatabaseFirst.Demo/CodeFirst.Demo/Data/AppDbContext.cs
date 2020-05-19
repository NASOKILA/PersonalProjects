using CodeFirst.Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Demo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {}

        public AppDbContext()
        {}

        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbConnect = Connection.DatabaseConnectionString;
            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(dbConnect);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
