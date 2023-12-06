using DataAccess.Models;
using DataAccess.Services.Mapping;
using DataAccess.Services.Mapping.Interfaces;
using Shared.DTOs;

namespace SOLID_DEMO_Tests.Tests_Mappers;

public class OrderMapper_Tests
{
    public IOrderMapper Mapper = new OrderMapper();

    [Fact]
    public void OrderMapper_MapToOrderModel_Return_OrderModel()
    {
        // Arrange

        var sut = Mapper;

        //Act

        var result = sut.MapToOrderModel(new OrderDto(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow.AddDays(3)));

        //Assert

        Assert.IsType<OrderModel>(result);
    }

    [Fact]
    public void OrderMapper_MapToOrderDto_Return_OrderDto()
    {
        // Arrange

        var sut = Mapper;

        //Act

        var result = sut.MapToOrderDto(new OrderModel(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow.AddDays(3)));

        //Assert

        Assert.IsType<OrderDto>(result);
    }
}