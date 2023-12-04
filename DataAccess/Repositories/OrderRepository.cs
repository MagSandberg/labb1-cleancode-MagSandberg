using DataAccess.Repositories.Interfaces;
using Shared.DTOs;

namespace DataAccess.Repositories;

public class OrderRepository : IOrderRepository
{
    public async Task<List<OrderDto>> GetOrders()
    {
        throw new NotImplementedException();
    }

    public async Task<OrderDto> GetOrder(Guid id)
    {
        throw new NotImplementedException();
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