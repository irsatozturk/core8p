using Microsoft.EntityFrameworkCore;
using proje1.Models;
using proje1.Data;

namespace proje1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        
        }

        public DbSet<Kategori> Kategoriler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>().HasData(
                new Kategori { Id = 4, Name = "Kategori 4", DisplayOrder = 3},    
                new Kategori { Id = 5, Name = "Kategori 5", DisplayOrder = 4},    
                new Kategori { Id = 6, Name = "Kategori 6", DisplayOrder = 5}    
            );
        }
    }
}
