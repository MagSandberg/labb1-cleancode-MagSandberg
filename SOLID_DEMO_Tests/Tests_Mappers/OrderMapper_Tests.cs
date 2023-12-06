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

    [Fact]
    public void OrderMapper_MapToOrderModel_Return_OrderModel_WithExpectedValues()
    {
        // Arrange

        var sut = Mapper;

        var orderDto = new OrderDto(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow.AddDays(3));
        var expectedId = orderDto.Id;
        var expectedOrderDate = orderDto.CreationTime;
        var expectedDeliveryDate = orderDto.ShippingDate;

        //Act

        var actualId = orderDto.Id;
        var actualOrderDate = orderDto.CreationTime;
        var actualDeliveryDate = orderDto.ShippingDate;
        var result = sut.MapToOrderModel(new OrderDto(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow.AddDays(3)));

        //Assert

        Assert.IsType<OrderModel>(result);
        Assert.Equal(expectedId, actualId);
        Assert.Equal(expectedOrderDate, actualOrderDate);
        Assert.Equal(expectedDeliveryDate, actualDeliveryDate);
    }
}