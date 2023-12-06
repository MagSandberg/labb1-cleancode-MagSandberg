using DataAccess.Models;
using DataAccess.Services.Mapping;
using DataAccess.Services.Mapping.Interfaces;
using Shared.DTOs;

namespace SOLID_DEMO_Tests.Tests_Mappers;

public class ProductMapper_Tests
{
    public IProductMapper Mapper = new ProductMapper();

    [Fact]
    public void ProductMapper_MapToProductModel_Return_ProductModel()
    {
        // Arrange

        var sut = Mapper;

        //Act

        var result = sut.MapToProductModel(new ProductDto("Test", 10.2, "1.0m"));

        //Assert

        Assert.IsType<ProductModel>(result);
    }

    [Fact]
    public void ProductMapper_MapToProductDto_Return_ProductDto()
    {
        // Arrange

        var sut = Mapper;

        //Act

        var result = sut.MapToProductDto(new ProductModel("Test", 10.2, "1.0m"));

        //Assert

        Assert.IsType<ProductDto>(result);
    }
}