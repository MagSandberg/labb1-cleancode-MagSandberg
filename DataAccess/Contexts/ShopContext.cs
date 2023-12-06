using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts;

public class ShopContext : DbContext
{
    public DbSet<CustomerModel> Customers { get; set; }
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<OrderModel> Orders { get; set; }
    public DbSet<CustomerOrderModel> CustomerOrders { get; set; }

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
        modelBuilder.Entity<OrderModel>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK_Orders");
            entity.HasMany(e => e.CustomerOrder)
                .WithOne(e => e.Order)
                .HasForeignKey(e => e.OrderId);
        });
    }

    public ShopContext(DbContextOptions options) : base(options)
    {

    }
}