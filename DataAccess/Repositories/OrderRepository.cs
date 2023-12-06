using DataAccess.Repositories.Interfaces;
using DataAccess.UnitOfWork.Interfaces;
using Shared.DTOs;

namespace DataAccess.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly IUnitOfWorkOrder _unitOfWorkOrder;

    public OrderRepository(IUnitOfWorkOrder unitOfWorkOrder)
    {
        _unitOfWorkOrder = unitOfWorkOrder;
    }

    public async Task<List<OrderDto>> GetOrders()
    {
        var orders = await _unitOfWorkOrder.GetOrders();

        return orders.ToList();
    }

    public async Task<OrderDto> GetOrder(Guid id)
    {
        var order = await _unitOfWorkOrder.GetOrder(id);

        return order;
    }

    public async Task<string> AddOrder(OrderDto order)
    {
        var result = await _unitOfWorkOrder.AddOrder(order);

        return result;
    }

    public async Task<string> UpdateOrder(OrderDto order, Guid id)
    {
        var result = await _unitOfWorkOrder.UpdateOrder(order, id);

        return result;
    }

    public async Task<string> DeleteOrder(Guid id)
    {
        var result = await _unitOfWorkOrder.DeleteOrder(id);

        return result;
    }
}