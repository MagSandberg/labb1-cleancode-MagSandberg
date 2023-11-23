using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Controllers;
using Server.DataAccess;
using Shared;

namespace SOLID_DEMO_Tests;

public class MainController_Product_Tests
{
    public static DbContextOptions _options = new DbContextOptionsBuilder<ShopContext>()
        .UseInMemoryDatabase(databaseName: "InMemory_CustomersDb")
        .Options;
    public static ShopContext _shopContext = new ShopContext(_options);
    public static MainController _mainController = new MainController(_shopContext);

    [Fact]
    public async Task MainController_AddProduct_Return_Ok()
    {
        //Arrange

        var sut = _mainController;

        //Act

        var result = await sut.AddProduct(new Product { Name = "Mouse", Description = "New Product" });

        //Assert

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task MainController_AddProduct_Return_BadRequest()
    {
        //Arrange

        var sut = _mainController;

        //Act

        var newProduct = await sut.AddProduct(new Product { Name = "Mouse", Description = "Test" });
        var result = await sut.AddProduct(new Product{ Name = "Mouse" , Description = "Test" });

        //Assert

        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task MainController_GetProducts_Return_Ok()
    {
        //Arrange

        var sut = _mainController;

        //Act

        var result = await sut.GetProducts();

        //Assert

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task MainController_GetProduct_Return_Ok()
    {
        //Arrange

        var sut = _mainController;

        //Act

        var result = await sut.GetProduct(1);

        //Assert

        Assert.IsType<OkObjectResult>(result);
    }
}