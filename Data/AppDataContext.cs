
using AlternativaTest.Data.Maps;
using AlternativaTest.Models;
using Microsoft.EntityFrameworkCore;

namespace AlternativaTest.Data
{
    public partial class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CategoryMap());
        }
    }
}