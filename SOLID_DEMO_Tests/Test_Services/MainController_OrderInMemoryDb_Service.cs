using Microsoft.EntityFrameworkCore;
using Server.Controllers;
using Server.DataAccess;
using Shared;

namespace SOLID_DEMO_Tests.Test_Services;

public class MainController_OrderInMemoryDb_Service
{
    public static DbContextOptions _options = new DbContextOptionsBuilder<ShopContext>()
        .UseInMemoryDatabase(databaseName: "InMemory_OrderDb")
        .Options;
    public static ShopContext _shopContext = new ShopContext(_options);
    public static MainController _mainController = new MainController(_shopContext);

    public async Task<MainController> OrderInMemoryDatabase()
    {
        var mainController = _mainController;

        var prodOne = new Product { Name = "Mouse", Description = "Mouse Description" };
        var prodTwo = new Product { Name = "Keyboard", Description = "Keyboard Description" };
        var prodThree = new Product { Name = "Screen", Description = "Screen Description" };

        var customerOne = new Customer("hej@gimajl.com", "123");

        var orderOne = new Order
        {
            Products = new List<Product> { prodOne, prodTwo, prodThree },
            Customer = customerOne,
            ShippingDate = DateTime.Now.AddDays(3)
        };

        await mainController._shopContext.Orders.AddAsync(orderOne);
        await mainController._shopContext.SaveChangesAsync();

        return mainController;
    }
}