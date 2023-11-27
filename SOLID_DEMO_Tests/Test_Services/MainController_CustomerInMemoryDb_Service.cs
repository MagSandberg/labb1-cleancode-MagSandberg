using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Server.Controllers;
using Server.DataAccess;
using Shared;

namespace SOLID_DEMO_Tests.Test_Services;

public class MainController_CustomerInMemoryDb_Service
{
    public static DbContextOptions _options = new DbContextOptionsBuilder<ShopContext>()
        .UseInMemoryDatabase(databaseName: "InMemory_CustomersDb")
        .Options;
    public static ShopContext _shopContext = new ShopContext(_options);
    public static MainController _mainController = new MainController(_shopContext);

    public async Task<MainController> CustomerInMemoryDb()
    {
        var mainController = _mainController;

        var customerOne = new CustomerModel("hej@gimajl.com", "123");
        var customerTwo = new CustomerModel("b@gimajl.com", "123");
        var customerThree = new CustomerModel("c@gimajl.com", "123");

        await mainController._shopContext.Customers.AddRangeAsync(customerOne, customerTwo, customerThree);
        await mainController._shopContext.SaveChangesAsync();

        return mainController;
    }
}