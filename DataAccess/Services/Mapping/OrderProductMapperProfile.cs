using DataAccess.Models;
using DataAccess.Services.Mapping.Interfaces;
using Shared.DTOs;

namespace DataAccess.Services.Mapping;

public class OrderProductMapperProfile : IOrderProductMapperProfile
{
    public OrderProductModel MapToOrderProductModel(OrderProductDto dto)
    {
        var model = new OrderProductModel(dto.ProductId, dto.Quantity);

        return model;
    }

    public OrderProductDto MapToOrderProductDto(OrderProductModel model)
    {
        var dto = new OrderProductDto(model.ProductId, model.Quantity);

        return dto;
    }
}