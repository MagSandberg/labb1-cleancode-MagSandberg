using DataAccess.Contexts;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace SOLID_DEMO_Tests.Test_ControllerServices;

public class ShopContext_With_ProductInMemoryDbService
{
    private static readonly DbContextOptions _options = new DbContextOptionsBuilder<ShopContext>()
        .UseInMemoryDatabase(databaseName: "ProductInMemoryDb")
        .Options;
    private readonly ShopContext _shopContext = new ShopContext(_options);

    public async Task<ShopContext> ProductInMemoryDb()
    {
        await _shopContext.Database.EnsureDeletedAsync();
        await _shopContext.Database.EnsureCreatedAsync();

        var prodOne = new ProductModel("Mouse", 2.24, "Mouse description");
        var prodTwo = new ProductModel("Keyboard", 5.55, "Keyboard description");
        var prodThree = new ProductModel("Screen", 123.80, "Screen description");

        await _shopContext.Products.AddRangeAsync(prodOne, prodTwo, prodThree);
        await _shopContext.SaveChangesAsync();

        return _shopContext;
    }
}