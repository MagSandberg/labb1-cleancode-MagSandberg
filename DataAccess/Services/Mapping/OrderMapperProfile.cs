using DataAccess.Models;
using DataAccess.Services.Mapping.Interfaces;
using Shared.DTOs;

namespace DataAccess.Services.Mapping;

public class OrderMapperProfile : IOrderMapperProfile
{
    public OrderModel MapToOrderModel(OrderDto dto)
    {
        var model = new OrderModel(dto.CustomerId, dto.CreationTime, dto.ShippingDate);
        if (dto.CustomerOrder != null)
        {
            model.CustomerOrder = dto.CustomerOrder.Select(co => new CustomerOrderModel(co.ProductId, co.Quantity)).ToList();
        }
        else
        {
            model.CustomerOrder = new List<CustomerOrderModel>();
        }

        return model;
    }

    public OrderDto MapToOrderDto(OrderModel model)
    {
        var dto = new OrderDto(model.CustomerId, model.CreationTime, model.ShippingDate);
        if (model.CustomerOrder != null)
        {
            dto.CustomerOrder = model.CustomerOrder.Select(co => new CustomerOrderDto(co.ProductId, co.Quantity)).ToList();
        }
        else
        {
            dto.CustomerOrder = new List<CustomerOrderDto>();
        }

        return dto;
    }
}
