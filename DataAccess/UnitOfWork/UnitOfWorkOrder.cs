using DataAccess.Contexts;
using DataAccess.Services.Mapping.Interfaces;
using DataAccess.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;

namespace DataAccess.UnitOfWork;

public class UnitOfWorkOrder : IUnitOfWorkOrder
{
    private readonly ShopContext _shopContext;
    private readonly IOrderMapperProfile _orderMapper;

    public UnitOfWorkOrder(ShopContext shopContext, IOrderMapperProfile orderMapper)
    {
        _shopContext = shopContext;
        _orderMapper = orderMapper;
    }

    public async Task<List<OrderDto>> GetOrders()
    {
        var orders = await _shopContext.Orders.ToListAsync();

        if (orders.Count == 0)
        {
            return new List<OrderDto>();
        }

        return orders.Select(order => _orderMapper.MapToOrderDto(order)).ToList();
    }

    public async Task<OrderDto> GetOrder(Guid id)
    {
        var order = await _shopContext.Orders.FirstOrDefaultAsync(o => o.OrderId.Equals(id));

        if (order == null)
        {
            return new OrderDto(Guid.Empty, Guid.Empty, DateTime.UtcNow, new List<OrderProductDto>());
        }

        return _orderMapper.MapToOrderDto(order);
    }

    public async Task<string> AddOrder(OrderDto order)
    {
        throw new NotImplementedException();
    }

    public async Task<string> UpdateOrder(OrderDto order, Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<string> DeleteOrder(Guid id)
    {
        throw new NotImplementedException();
    }
}