using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts;

public class ShopContext : DbContext
{
    public DbSet<CustomerModel> Customers { get; set; }
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<OrderModel> Orders { get; set; }
    public DbSet<OrderProductModel> OrderProducts { get; set; }

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
        });

        modelBuilder.Entity<OrderProductModel>()
            .HasKey(op => new { op.OrderProductId });

        modelBuilder.Entity<OrderProductModel>()
            .HasOne(op => op.Order)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(op => op.OrderId);

        modelBuilder.Entity<OrderProductModel>()
            .HasOne(op => op.Product)
            .WithMany(p => p.OrderProducts)
            .HasForeignKey(op => op.ProductId);
    }

    public ShopContext(DbContextOptions options) : base(options)
    {

    }
}