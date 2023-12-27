using Microsoft.EntityFrameworkCore;
using SmapleWebAPI.Model;
using System.Collections.Generic;

namespace SmapleWebAPI.Data
{
    public class ProductAPIContext : DbContext
    {
        public ProductAPIContext(DbContextOptions<ProductAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Model.Product>? Product { get; set; }
        public DbSet<Model.Category>? Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().ToTable("Product");
        }
    }
    
}
