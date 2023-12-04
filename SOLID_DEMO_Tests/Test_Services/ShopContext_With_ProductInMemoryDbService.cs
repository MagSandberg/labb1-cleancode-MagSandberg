using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Server.DataAccess;

namespace SOLID_DEMO_Tests.Test_Services;

public class ShopContext_With_ProductInMemoryDbService
{
    public static DbContextOptions _options = new DbContextOptionsBuilder<ShopContext>()
        .UseInMemoryDatabase(databaseName: "ProductInMemoryDb")
        .Options;
    public ShopContext _shopContext = new ShopContext(_options);

    public async Task<ShopContext> ProductInMemoryDb()
    {
        await _shopContext.Database.EnsureDeletedAsync();
        await _shopContext.Database.EnsureCreatedAsync();

        var prodOne = new ProductModel( Guid.NewGuid(), "Mouse", 2.24, "Mouse description" );
        var prodTwo = new ProductModel(Guid.NewGuid(), "Keyboard", 5.55, "Keyboard description");
        var prodThree = new ProductModel( Guid.NewGuid(), "Screen", 123.80, "Screen description" );

        await _shopContext.Products.AddRangeAsync(prodOne, prodTwo, prodThree);
        await _shopContext.SaveChangesAsync();

        return _shopContext;
    }
}