using Microsoft.EntityFrameworkCore;
using Server.Controllers;
using Server.DataAccess;
using Shared;

namespace SOLID_DEMO_Tests.Test_Services;

public class MainController_InMemoryDb_Service
{
    public async Task<ShopContext> InMemoryDatabase()
    {
        var options = new DbContextOptionsBuilder<ShopContext>()
            .UseInMemoryDatabase(databaseName: "InMemory_OrdersDb")
            .Options;
        var shopDbContext = new ShopContext(options);

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

        await shopDbContext.Orders.AddAsync(orderOne);
        await shopDbContext.SaveChangesAsync();

        return shopDbContext;
    }

    public async Task<MainController> CustomerInMemoryDb()
    {
        var options = new DbContextOptionsBuilder<ShopContext>()
            .UseInMemoryDatabase(databaseName: "InMemory_CustomersDb")
            .Options;
        var shopDbContext = new ShopContext(options);
        var mainController = new MainController(shopDbContext);

        var customerOne = new Customer("hej@gimajl.com", "123");
        var customerTwo = new Customer("b@gimajl.com", "123");
        var customerThree = new Customer("c@gimajl.com", "123");

        await shopDbContext.Customers.AddRangeAsync(customerOne, customerTwo, customerThree);
        await shopDbContext.SaveChangesAsync();

        return mainController;
    }
}