using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using DataAccess.Services.Mapping;
using DataAccess.Services.Mapping.Interfaces;
using DataAccess.UnitOfWork;
using DataAccess.UnitOfWork.Interfaces;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers;
using Shared.DTOs;
using SOLID_DEMO_Tests.Test_Services;

namespace SOLID_DEMO_Tests;

public class ProductController_Tests
{
    private static readonly IProductMapper ProductMapper = new ProductMapper();

    private static readonly ShopContext_With_ProductInMemoryDbService _productInMemoryDbService = new ShopContext_With_ProductInMemoryDbService();
    private static readonly IUnitOfWorkProduct _unitOfWork = new UnitOfWorkProduct(_productInMemoryDbService.ProductInMemoryDb().Result, ProductMapper);

    private static readonly IProductRepository _productRepository = new ProductRepository(_unitOfWork);

    private static readonly ProductController _productController = new ProductController(_productRepository);


    [Fact]
    public async Task ProductController_GetProducts_Return_Ok()
    {
        // Arrange
        var sut = _productController;

        // Act

        var result = await sut.GetProducts();

        // Assert

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task ProductController_GetProducts_Return_NotFound()
    {
        // Arrange
        var fakeProductRepository = A.Fake<IProductRepository>();
        var sut = new ProductController(fakeProductRepository);

        // Act
        var result = await sut.GetProducts();

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public async Task ProductController_GetProduct_Return_Ok()
    {
        // Arrange
        var sut = _productController;

        var products = await _productRepository.GetProducts();
        var productId = products[0].Id;

        // Act
        var result = await sut.GetProduct(productId);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task ProductController_GetProduct_Return_NotFound()
    {
        // Arrange
        var sut = _productController;

        // Act
        var result = await sut.GetProduct(Guid.NewGuid());

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public async Task ProductController_AddProduct_Return_Ok()
    {
        // Arrange
        var sut = _productController;

        // Act
        var result = await sut.AddProduct( new ProductDto("AddProduct", 100, "Product description"));

        // Assert
        Assert.IsType<OkObjectResult>(result);

        var okObjectResult = (OkObjectResult)result;
        var value = okObjectResult.Value;

        Assert.Equal("Product added successfully.", value);
    }

    [Fact]
    public async Task ProductController_AddProduct_Return_BadRequest()
    {
        // Arrange
        var sut = _productController;

        var oldProduct = new ProductDto("Mouse", 100, "Product description");
        var newProduct = new ProductDto("Mouse", 100, "Product description");

        var addProduct = await sut.AddProduct(oldProduct);
        
        // Act
        var result = await sut.AddProduct(newProduct);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);

        var badRequestObjectResult = (BadRequestObjectResult)result;
        var value = badRequestObjectResult.Value;

        Assert.Equal("Product already exists.", value);
    }

    [Fact]
    public async Task ProductController_UpdateProduct_Return_Ok()
    {
        // Arrange
        var sut = _productController;

        var products = await _productRepository.GetProducts();
        var productId = products[0].Id;

        var updatedProduct = new ProductDto("Updated Product", 100, "Product description");

        // Act
        var result = await sut.UpdateProduct(updatedProduct, productId);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task ProductController_UpdateProduct_Return_BadRequest()
    {
        // Arrange
        var sut = _productController;

        var updatedProduct = new ProductDto("Updated Product", 100, "Product description");

        // Act
        var result = await sut.UpdateProduct(updatedProduct, Guid.NewGuid());

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);

        var badRequestObjectResult = (BadRequestObjectResult)result;
        var value = badRequestObjectResult.Value;

        Assert.Equal("Product does not exist.", value);
    }

    [Fact]
    public async Task ProductController_DeleteProduct_Return_Ok()
    {
        // Arrange
        var sut = _productController;

        var newProduct = new ProductDto("New Product", 100, "Product description");
        await sut.AddProduct(newProduct);

        var productToDelete = await _productRepository.GetProduct(newProduct.Id);
        var productToDeleteId = productToDelete.Id;

        // Act
        var result = await sut.DeleteProduct(productToDeleteId);

        // Assert
        Assert.IsType<OkObjectResult>(result);

        var okObjectResult = (OkObjectResult)result;
        var value = okObjectResult.Value;

        Assert.Equal("Product deleted successfully.", value);
    }

    [Fact]
    public async Task ProductController_DeleteProduct_Return_BadRequest()
    {
        // Arrange
        var sut = _productController;

        // Act
        var result = await sut.DeleteProduct(Guid.NewGuid());

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);

        var badRequestObjectResult = (BadRequestObjectResult)result;
        var value = badRequestObjectResult.Value;

        Assert.Equal("Product does not exist.", value);
    }
}
