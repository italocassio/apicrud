using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Store.Data
{
    public class StoreDataContext : DbContext
    {
        public StoreDataContext(DbContextOptions<StoreDataContext> options)
                            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Usuario>().HasKey(x => x.Id);
        }
    }
}