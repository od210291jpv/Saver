using Microsoft.EntityFrameworkCore;

namespace SaverBackend.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Content> Contents { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=192.168.0.101;Database=mobilesdb;Uid=root@localhost;Pwd=password;");
        }
    }
}
