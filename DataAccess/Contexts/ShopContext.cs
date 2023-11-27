using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Server.DataAccess;

public class ShopContext : DbContext
{
    public DbSet<CustomerModel> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    public ShopContext(DbContextOptions options) : base(options)
    {

    }
}