using Shared.DTOs;

namespace DataAccess.UnitOfWork.Interfaces;

public interface IUnitOfWorkOrder
{
    Task<List<OrderDto>> GetOrders();
    Task<OrderDto> GetOrder(Guid id);
    Task<string> AddOrder(OrderDto order);
    Task<string> UpdateOrder(OrderDto order, Guid id);
    Task<string> DeleteOrder(Guid id);
}