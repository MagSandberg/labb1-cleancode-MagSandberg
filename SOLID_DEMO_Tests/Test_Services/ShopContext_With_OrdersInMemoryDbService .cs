using DataAccess.Contexts;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace SOLID_DEMO_Tests.Test_Services;

public class ShopContext_With_OrdersInMemoryDbService
{
    private static readonly DbContextOptions _options = new DbContextOptionsBuilder<ShopContext>()
        .UseInMemoryDatabase(databaseName: "OrderInMemoryDb")
        .Options;
    private readonly ShopContext _shopContext = new ShopContext(_options);

    public async Task<ShopContext> OrdersInMemoryDb()
    {
        await _shopContext.Database.EnsureDeletedAsync();
        await _shopContext.Database.EnsureCreatedAsync();

        var orderOne = new OrderModel(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow.AddDays(3)) { OrderId = Guid.NewGuid() };
        orderOne.CustomerOrder.Add(new CustomerOrderModel(Guid.NewGuid(), 1) { Id = Guid.NewGuid(), OrderId = orderOne.OrderId});

        var orderTwo = new OrderModel(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow.AddDays(3)) { OrderId = Guid.NewGuid() };
        orderTwo.CustomerOrder.Add(new CustomerOrderModel(Guid.NewGuid(), 2) { Id = Guid.NewGuid(), OrderId = orderTwo.OrderId });

        var orderThree = new OrderModel(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow.AddDays(3)) { OrderId = Guid.NewGuid() };
        orderThree.CustomerOrder.Add(new CustomerOrderModel(Guid.NewGuid(), 3){ Id = Guid.NewGuid(), OrderId = orderThree.OrderId});

        await _shopContext.Orders.AddRangeAsync(orderOne, orderTwo, orderThree);
        await _shopContext.SaveChangesAsync();

        return _shopContext;
    }
}