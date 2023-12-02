using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Server.DataAccess;

public class ShopContext : DbContext
{
    public DbSet<CustomerModel> Customers { get; set; }
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerModel>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK_Customers");
        });

        modelBuilder.Entity<ProductModel>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_Products");
        });
    }

    public ShopContext(DbContextOptions options) : base(options)
    {

    }
}