using DataAccess.Contexts;
using DataAccess.Models;
using DataAccess.Services.Mapping.Interfaces;
using DataAccess.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;
using System.Linq;

namespace DataAccess.UnitOfWork;

public class UnitOfWorkOrder : IUnitOfWorkOrder
{
    private readonly ShopContext _shopContext;
    private readonly IOrderMapperProfile _orderMapper;
    private readonly ICustomerOrderMapper _customerOrderMapper;

    public UnitOfWorkOrder(ShopContext shopContext, IOrderMapperProfile orderMapper, ICustomerOrderMapper customerOrderMapper)
    {
        _shopContext = shopContext;
        _orderMapper = orderMapper;
        _customerOrderMapper = customerOrderMapper;
    }

    public async Task<List<OrderDto>> GetOrders()
    {
        var orders = await _shopContext.Orders.ToListAsync();

        if (orders.Count == 0)
        {
            return new List<OrderDto>();
        }

        var customerOrders = await _shopContext.CustomerOrders.ToListAsync();

        foreach (var order in orders)
        {
            order.CustomerOrder = customerOrders.Where(co => co.OrderId == order.OrderId).ToList();
        }

        return orders.Select(order => _orderMapper.MapToOrderDto(order)).ToList();
    }

    public async Task<OrderDto> GetOrder(Guid id)
    {
        var order = await _shopContext.Orders.FirstOrDefaultAsync(o => o.OrderId.Equals(id));

        if (order == null)
        {
            return new OrderDto(Guid.Empty, DateTime.UtcNow, DateTime.UtcNow.AddDays(3));
        }

        if (order.CustomerId.Equals(Guid.Empty))
        {
            return new OrderDto(Guid.Empty, order.CreationTime, order.ShippingDate);
        }

        return _orderMapper.MapToOrderDto(order);
    }

    public async Task<string> AddOrder(OrderDto order)
    {
        var orderModel = new OrderModel(order.CustomerId, DateTime.UtcNow, DateTime.UtcNow.AddDays(3));

        foreach (var customerOrderDto in order.CustomerOrder)
        {
            var customerOrderModel = new CustomerOrderModel(customerOrderDto.ProductId, customerOrderDto.Quantity);
            customerOrderModel.Order = orderModel;
            orderModel.CustomerOrder.Add(customerOrderModel);
        }

        await _shopContext.Orders.AddAsync(orderModel);
        await _shopContext.SaveChangesAsync();

        return "Order added successfully.";
    }

    public async Task<string> UpdateOrder(OrderDto order, Guid id)
    {
        var orderExists = await _shopContext.Orders.FirstOrDefaultAsync(o => o.OrderId.Equals(order.Id));
        if (orderExists is null) return "Order does not exist.";

        _shopContext.Orders.Update(_orderMapper.MapToOrderModel(order));

        orderExists.CustomerId = order.CustomerId;
        orderExists.ShippingDate = order.ShippingDate;

        var products = new List<OrderProductModel>();

        //foreach (var orderProduct in order.OrderProducts)
        //{
        //    var product = await _shopContext.Products.FirstOrDefaultAsync(p => p.ProductId.Equals(orderProduct.ProductId));
        //    if (product is null) return "Product does not exist.";

        //    products.Add(_orderProductMapper.MapToOrderProductModel(orderProduct));
        //}

        //orderExists.OrderProducts = products;

        var result = await _shopContext.SaveChangesAsync();

        return result > 0 ? "Order updated successfully." : "Failed to update order.";
    }

    public async Task<string> DeleteOrder(Guid id)
    {
        var orderExists = await _shopContext.Orders.FirstOrDefaultAsync(o => o.OrderId.Equals(id));
        if (orderExists is null) return "Order does not exist.";

        _shopContext.Orders.Remove(orderExists);

        var result = await _shopContext.SaveChangesAsync();

        return result > 0 ? "Order deleted successfully." : "Failed to delete order.";
    }
}