using Microsoft.EntityFrameworkCore;

namespace diplom.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet<products> product { get; set; }

        public DbSet<Category> categories { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options)
          : base((DbContextOptions)options)
          => this.Database.EnsureCreated();
    }
}
