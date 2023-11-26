using Microsoft.AspNetCore.Mvc;
using Shared;
using SOLID_DEMO_Tests.Test_Services;

namespace SOLID_DEMO_Tests;

public class MainController_Order_Tests
{
    private static readonly MainController_InMemoryDb_Service InMemoryDbService = new();

    [Fact]
    public async Task MainController_GetAllOrders_Returns_Ok()
    {
        //Arrange

        var sut = await InMemoryDbService.OrderInMemoryDatabase();

        //Act

        var result = await sut.GetAllOrders();

        //Assert

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task MainController_GetOrdersForCustomers_Returns_Ok()
    {
        //Arrange

        var sut = await InMemoryDbService.OrderInMemoryDatabase();
        var customerId = sut._shopContext.Customers.FirstOrDefault(c => c.Name == "hej@gimajl.com");

        //Act

        var result = await sut.GetOrdersForCustomer(customerId.Id);

        //Assert

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task MainController_GetOrdersForCustomers_Returns_NotFound()
    {
        //Arrange

        var sut = await InMemoryDbService.OrderInMemoryDatabase();

        //Act

        var result = await sut.GetOrdersForCustomer(99);

        //Assert

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task MainController_PlaceOrder_Returns_Ok()
    {
        //Arrange

        var sut = await InMemoryDbService.OrderInMemoryDatabase();

        var customer = sut._shopContext.Customers.FirstOrDefault(c => c.Name == "hej@gimajl.com");
        var customerId = customer.Id;

        var product = sut._shopContext.Products.FirstOrDefault(p => p.Name == "Mouse");
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

        var sut = await InMemoryDbService.OrderInMemoryDatabase();

        //Act

        var result = await sut.PlaceOrder(new CustomerCart { ProductIds = new List<int> { 1 }, CustomerId = 2 });

        //Assert

        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task MainController_PlaceOrder_Returns_NotFound()
    {
        //Arrange

        var sut = await InMemoryDbService.OrderInMemoryDatabase();


        var customer = sut._shopContext.Customers.FirstOrDefault(c => c.Name == "hej@gimajl.com");
        var customerId = customer.Id;

        //Act

        var result = await sut.PlaceOrder(new CustomerCart { ProductIds = new List<int> { 345 }, CustomerId = customerId });

        //Assert

        Assert.IsType<NotFoundResult>(result);
    }
}