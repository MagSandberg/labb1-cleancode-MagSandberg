using DataAccess.Models;
using DataAccess.Services.Mapping.Interfaces;
using Shared.DTOs;

namespace DataAccess.Services.Mapping;

public class OrderMapperProfile : IOrderMapperProfile
{
    public OrderModel MapToOrderModel(OrderDto dto)
    {
        var model = new OrderModel(dto.Id, dto.CustomerId, dto.ShippingDate, new List<OrderProductModel>());

        return model;
    }

    public OrderDto MapToOrderDto(OrderModel model)
    {
        var dto = new OrderDto(model.OrderId, model.CustomerId, model.ShippingDate, new List<OrderProductDto>());

        return dto;
    }
}