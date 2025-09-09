using Microsoft.EntityFrameworkCore;
using Task1mvc.Models;

namespace Task1mvc.Data
{
    public class ApplicationDbContext : DbContext {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=.;Database=MVC_1;TrustServerCertificate=True;Trusted_Connection=True");
        }
    }
}
