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

        var customerOne = new CustomerModel("Firstname", "Lastname", "first@last.com", "123123123");

        var customerTwo = new CustomerModel("Secondname", "Lastname", "second@last.com", "123123123");

        var customerThree = new CustomerModel("Thirdname", "Lastname", "third@last.com", "123123123");

        await _shopContext.Customers.AddRangeAsync(customerOne, customerTwo, customerThree);
        await _shopContext.SaveChangesAsync();

        return _shopContext;
    }
}