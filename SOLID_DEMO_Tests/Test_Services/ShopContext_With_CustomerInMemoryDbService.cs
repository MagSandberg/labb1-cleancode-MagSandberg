using DataAccess.Contexts;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace SOLID_DEMO_Tests.Test_Services;

public class ShopContext_With_CustomerInMemoryDbService
{
    private static readonly DbContextOptions _options = new DbContextOptionsBuilder<ShopContext>()
        .UseInMemoryDatabase(databaseName: "CustomerInMemoryDb")
        .Options;
    private readonly ShopContext _shopContext = new ShopContext(_options);

    public async Task<ShopContext> CustomerInMemoryDb()
    {
        await _shopContext.Database.EnsureDeletedAsync();
        await _shopContext.Database.EnsureCreatedAsync();

        var customerOne = new CustomerModel(Guid.NewGuid(), "Ana", "Anason", "ana@ana.com", "123123123", new List<OrderModel>());

        var customerTwo = new CustomerModel(Guid.NewGuid(), "Bnb", "Bnbson", "bnb@bnb.com", "123123123", new List<OrderModel>());

        var customerThree = new CustomerModel(Guid.NewGuid(), "Cnc", "Cncson", "cnc@cnc.com", "123123123", new List<OrderModel>());

        await _shopContext.Customers.AddRangeAsync(customerOne, customerTwo, customerThree);
        await _shopContext.SaveChangesAsync();

        return _shopContext;
    }
}