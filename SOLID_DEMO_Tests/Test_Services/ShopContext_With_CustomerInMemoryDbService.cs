using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Server.DataAccess;

namespace SOLID_DEMO_Tests.Test_Services;

public class ShopContext_With_CustomerInMemoryDbService
{
    public static DbContextOptions _options = new DbContextOptionsBuilder<ShopContext>()
        .UseInMemoryDatabase(databaseName: "CustomerInMemoryDb")
        .Options;
    public ShopContext _shopContext = new ShopContext(_options);

    public async Task<ShopContext> CustomerInMemoryDb()
    {
        await _shopContext.Database.EnsureDeletedAsync();
        await _shopContext.Database.EnsureCreatedAsync();

        var customerOne = new CustomerModel("ana@ana.com", "123123123", "Ana", "Anason", Guid.NewGuid());
        var customerTwo = new CustomerModel("bnb@bnb.com", "123123123", "Bnb", "Bnbson", Guid.NewGuid());
        var customerThree = new CustomerModel("cnc@cnc.com", "123123123", "Cnc", "Cncson", Guid.NewGuid());

        await _shopContext.Customers.AddRangeAsync(customerOne, customerTwo, customerThree);
        await _shopContext.SaveChangesAsync();

        return _shopContext;
    }
}