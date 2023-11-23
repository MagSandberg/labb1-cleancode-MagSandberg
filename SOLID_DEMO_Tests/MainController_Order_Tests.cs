using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Controllers;
using Server.DataAccess;
using Shared;

namespace SOLID_DEMO_Tests;

public class MainController_Order_Tests
{
    public static async Task<ShopContext> InMemoryDatabase()
    {
        var options = new DbContextOptionsBuilder<ShopContext>()
        .UseInMemoryDatabase(databaseName: "InMemory_CustomersDb")
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

    [Fact]
    public async Task MainController_GetAllOrders_Returns_Ok()
    {
        //Arrange

        var sut = new MainController(await InMemoryDatabase());

        //Act

        var orders = await sut.GetAllOrders();

        //Assert

        Assert.IsType<OkObjectResult>(orders);
    }

    [Fact]
    public async Task MainController_GetOrdersForCustomers_Returns_Ok()
    {
        //Arrange

        var sut = new MainController(await InMemoryDatabase());

        var customerId = InMemoryDatabase().Result.Customers.FirstOrDefaultAsync(c => c.Name == "hej@gimajl.com").Id;

        //Act

        var orders = await sut.GetOrdersForCustomer(customerId);

        //Assert

        Assert.IsType<OkObjectResult>(orders);
    }

    [Fact]
    public async Task MainController_GetOrdersForCustomers_Returns_NotFound()
    {
        //Arrange

        var sut = new MainController(await InMemoryDatabase());

        //Act

        var orders = await sut.GetOrdersForCustomer(99);

        //Assert

        Assert.IsType<NotFoundResult>(orders);
    }

    [Fact]
    public async Task MainController_PlaceOrder_Returns_Ok()
    {
        //Arrange

        var sut = new MainController(await InMemoryDatabase());

        var customer = InMemoryDatabase().Result.Customers.FirstOrDefault(c => c.Name == "hej@gimajl.com");
        var customerId = customer.Id;

        var product = InMemoryDatabase().Result.Products.FirstOrDefault(p => p.Name == "Mouse");
        var productId = product.Id;

        //Act

        var result = await sut.PlaceOrder(new CustomerCart { ProductIds = new List<int> { productId }, CustomerId = customerId });

        //Assert

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task MainController_PlaceOrder_Returns_BadRequest()
    {
        //Arrange

        var sut = new MainController(await InMemoryDatabase());

        //Act

        var result = await sut.PlaceOrder(new CustomerCart { ProductIds = new List<int> { 1 }, CustomerId = 2 });

        //Assert

        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task MainController_PlaceOrder_Returns_NotFound()
    {
        //Arrange

        var sut = new MainController(await InMemoryDatabase());

        var customer = InMemoryDatabase().Result.Customers.FirstOrDefault(c => c.Name == "hej@gimajl.com");
        var customerId = customer.Id;

        //Act

        var result = await sut.PlaceOrder(new CustomerCart { ProductIds = new List<int> { 345 }, CustomerId = customerId });

        //Assert

        Assert.IsType<NotFoundResult>(result);
    }
}