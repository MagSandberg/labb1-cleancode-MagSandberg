using Microsoft.EntityFrameworkCore;
using Server.Controllers;
using Server.DataAccess;
using Shared;

namespace SOLID_DEMO_Tests.Test_Services;

public class MainController_InMemoryDb_Service
{
    public static DbContextOptions _options = new DbContextOptionsBuilder<ShopContext>()
        .UseInMemoryDatabase(databaseName: "InMemory_CustomersDb")
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

    public async Task<MainController> CustomerInMemoryDb()
    {
        var mainController = _mainController;

        var customerOne = new Customer("hej@gimajl.com", "123");
        var customerTwo = new Customer("b@gimajl.com", "123");
        var customerThree = new Customer("c@gimajl.com", "123");

        await mainController._shopContext.Customers.AddRangeAsync(customerOne, customerTwo, customerThree);
        await mainController._shopContext.SaveChangesAsync();

        return mainController;
    }

    public async Task<MainController> ProductInMemoryDb()
    {
        var mainController = _mainController;

        var prodOne = new Product { Name = "Apple", Description = "Apple Description" };
        var prodTwo = new Product { Name = "Banana", Description = "Banana Description" };
        var prodThree = new Product { Name = "Pear", Description = "Pear Description" };

        await mainController._shopContext.Products.AddRangeAsync(prodOne, prodTwo, prodThree);
        await mainController._shopContext.SaveChangesAsync();

        return mainController;
    }
}