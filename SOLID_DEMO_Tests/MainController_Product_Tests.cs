using Microsoft.AspNetCore.Mvc;
using Shared;
using SOLID_DEMO_Tests.Test_Services;

namespace SOLID_DEMO_Tests;

public class MainController_Product_Tests
{
    private static readonly MainController_ProductInMemoryDb_Service ProductInMemoryDbService = new();

    //[Fact]
    //public async Task MainController_AddProduct_Return_Ok()
    //{
    //    //Arrange

    //    var sut = await ProductInMemoryDbService.ProductInMemoryDb();

    //    //Act

    //    var result = await sut.AddProduct(new Product { Name = "Orange", Description = "Orange Description" });

    //    //Assert

    //    Assert.IsType<OkResult>(result);
    //}

    //[Fact]
    //public async Task MainController_AddProduct_Return_BadRequest()
    //{
    //    //Arrange

    //    var sut = await ProductInMemoryDbService.ProductInMemoryDb();

    //    //Act

    //    var result = await sut.AddProduct(new Product { Name = "Apple", Description = "New Apple Description" });

    //    //Assert

    //    Assert.IsType<BadRequestResult>(result);
    //}

    //[Fact]
    //public async Task MainController_GetProducts_Return_Ok()
    //{
    //    //Arrange

    //    var sut = await ProductInMemoryDbService.ProductInMemoryDb();

    //    //Act

    //    var result = await sut.GetProducts();

    //    //Assert

    //    Assert.IsType<OkObjectResult>(result);
    //}

    //[Fact]
    //public async Task MainController_GetProduct_Return_Ok()
    //{
    //    //Arrange

    //    var sut = await ProductInMemoryDbService.ProductInMemoryDb();

    //    //Act

    //    var result = await sut.GetProduct(1);

    //    //Assert

    //    Assert.IsType<OkObjectResult>(result);
    //}
}