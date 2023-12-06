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
using SOLID_DEMO_Tests.Test_ControllerServices;

namespace SOLID_DEMO_Tests.Tests_Controllers;

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

        var orderToUpdate = orders[0];
        orderToUpdate.ShippingDate = DateTime.UtcNow.AddDays(3);

        var customerOrder = new CustomerOrderModel(Guid.NewGuid(), 1) { Id = Guid.NewGuid(), OrderId = orderToUpdate.Id };
        orderToUpdate.CustomerOrder.Add(_customerOrderMapper.MapToCustomerOrderDto(customerOrder));

        // Act

        var result = await sut.UpdateOrder(orderToUpdate, orderId);

        // Assert

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task OrderController_UpdateOrder_Return_BadRequest()
    {
        // Arrange
        var sut = _orderController;

        var orders = await _orderRepository.GetOrders();
        var orderId = orders[0].Id;

        var orderToUpdate = orders[0];
        orderToUpdate.ShippingDate = DateTime.UtcNow.AddDays(3);

        var customerOrder = new CustomerOrderModel(Guid.NewGuid(), 1) { Id = Guid.NewGuid(), OrderId = orderToUpdate.Id };
        orderToUpdate.CustomerOrder.Add(_customerOrderMapper.MapToCustomerOrderDto(customerOrder));

        // Act

        var result = await sut.UpdateOrder(orderToUpdate, Guid.Empty);

        // Assert

        Assert.IsType<BadRequestObjectResult>(result);

        var badRequestObjectResult = (BadRequestObjectResult)result;
        var value = badRequestObjectResult.Value;

        Assert.Equal("Order does not exist.", value);
    }

    [Fact]
    public async Task OrderController_DeleteOrder_Return_Ok()
    {
        // Arrange
        var sut = _orderController;

        var orders = await _orderRepository.GetOrders();
        var orderId = orders[0].Id;

        // Act

        var result = await sut.DeleteOrder(orderId);

        // Assert

        Assert.IsType<OkObjectResult>(result);

        var okObjectResult = (OkObjectResult)result;
        var value = okObjectResult.Value;

        Assert.Equal("Order deleted successfully.", value);
    }

    [Fact]
    public async Task OrderController_DeleteOrder_Return_BadRequest()
    {
        // Arrange
        var sut = _orderController;

        // Act

        var result = await sut.DeleteOrder(Guid.Empty);

        // Assert

        Assert.IsType<BadRequestObjectResult>(result);

        var badRequestObjectResult = (BadRequestObjectResult)result;
        var value = badRequestObjectResult.Value;

        Assert.Equal("Order does not exist.", value);
    }
}
