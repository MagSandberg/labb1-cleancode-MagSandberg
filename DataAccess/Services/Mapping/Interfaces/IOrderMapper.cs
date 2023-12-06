using DataAccess.Models;
using Shared.DTOs;

namespace DataAccess.Services.Mapping.Interfaces;

public interface IOrderMapper
{
    public OrderModel MapToOrderModel(OrderDto dto);
    public OrderDto MapToOrderDto(OrderModel model);
}