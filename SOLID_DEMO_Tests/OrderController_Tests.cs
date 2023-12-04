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
    private static readonly IOrderMapperProfile _orderMapperProfile = new OrderMapperProfile();

    private static readonly ShopContext_With_OrderInMemoryDbService _orderInMemoryDbService = new ShopContext_With_OrderInMemoryDbService();
    private static readonly IUnitOfWorkOrder _unitOfWork = new UnitOfWorkOrder(_orderInMemoryDbService.OrdersInMemoryDb().Result, _orderMapperProfile);

    private static readonly IOrderRepository _orderRepository = new OrderRepository(_unitOfWork);

    private static readonly OrderController _orderController = new OrderController(_orderRepository);


    [Fact]
    public async Task OrderController_GetOrder_Return_Ok()
    {
        // Arrange
        var sut = _orderController;

        // Act

        var result = await sut.GetOrders();

        // Assert

        Assert.IsType<OkObjectResult>(result);
    }
}
