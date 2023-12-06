using DataAccess.Models;
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

public class OrderController_Tests
{
    private static readonly IOrderMapper _orderMapper = new OrderMapper();
    private static readonly ICustomerOrderMapper _customerOrderMapper = new CustomerOrderMapper();

    private static readonly ShopContext_With_OrdersInMemoryDbService _orderInMemoryDbService = new ShopContext_With_OrdersInMemoryDbService();
    private static readonly IUnitOfWorkOrder _unitOfWork = new UnitOfWorkOrder(_orderInMemoryDbService.OrdersInMemoryDb().Result, _orderMapper, _customerOrderMapper);

    private static readonly IOrderRepository _orderRepository = new OrderRepository(_unitOfWork);

    private static readonly OrderController _orderController = new OrderController(_orderRepository);


    [Fact]
    public async Task OrderController_GetOrders_Return_Ok()
    {
        // Arrange
        var sut = _orderController;

        // Act

        var result = await sut.GetOrders();

        // Assert

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task OrderController_GetOrders_Return_NotFound()
    {
        // Arrange
        var fakeOrderRepository = A.Fake<IOrderRepository>();
        var sut = new OrderController(fakeOrderRepository);

        // Act

        var result = await sut.GetOrders();

        // Assert

        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public async Task OrderController_GetOrder_Return_Ok()
    {
        // Arrange
        var sut = _orderController;

        var orders = await _orderRepository.GetOrders();
        var orderId = orders[0].Id;

        // Act

        var result = await sut.GetOrder(orderId);

        // Assert

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task OrderController_GetOrder_Return_NotFound()
    {
        // Arrange
        var sut = _orderController;

        // Act

        var result = await sut.GetOrder(Guid.Empty);

        // Assert

        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public async Task OrderController_AddOrder_Return_Ok()
    {
        // Arrange
        var sut = _orderController;

        var newOrder = new OrderModel(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow.AddDays(3)) { OrderId = Guid.NewGuid() };
        newOrder.CustomerOrder.Add(new CustomerOrderModel(Guid.NewGuid(), 1) { Id = Guid.NewGuid(), OrderId = newOrder.OrderId });

        // Act

        var result = await sut.AddOrder(_orderMapper.MapToOrderDto(newOrder));

        // Assert

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task OrderController_AddOrder_Return_BadRequest()
    {
        // Arrange
        var sut = _orderController;

        var newOrder = new OrderModel(Guid.Empty, DateTime.UtcNow, DateTime.UtcNow.AddDays(3));
        newOrder.CustomerOrder.Add(new CustomerOrderModel(Guid.NewGuid(), 1));

        // Act

        var result = await sut.AddOrder(_orderMapper.MapToOrderDto(newOrder));

        // Assert

        Assert.IsType<BadRequestObjectResult>(result);

        var badRequestObjectResult = (BadRequestObjectResult)result;
        var value = badRequestObjectResult.Value;

        Assert.Equal("Customer Id is empty.", value);
    }

    [Fact]
    public async Task OrderController_UpdateOrder_Return_Ok()
    {
        // Arrange
        var sut = _orderController;

        var orders = await _orderRepository.GetOrders();
        var orderId = orders[0].Id;

        var newOrder = new OrderModel(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow.AddDays(3)) { OrderId = orderId };
        newOrder.CustomerOrder.Add(new CustomerOrderModel(Guid.NewGuid(), 1) { Id = Guid.NewGuid(), OrderId = newOrder.OrderId });

        // Act

        var result = await sut.UpdateOrder(_orderMapper.MapToOrderDto(newOrder), orderId);

        // Assert

        Assert.IsType<OkObjectResult>(result);
    }
}
