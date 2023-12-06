using DataAccess.Models;
using DataAccess.Services.Mapping.Interfaces;
using Shared.DTOs;

namespace DataAccess.Services.Mapping;

public class CustomerOrderMapper : ICustomerOrderMapper
{
    public CustomerOrderModel MapToCustomerOrderModel(CustomerOrderDto dto)
    {
        var model = new CustomerOrderModel(dto.ProductId, dto.Quantity);

        return model;
    }

    public CustomerOrderDto MapToCustomerOrderDto(CustomerOrderModel model)
    {
        var dto = new CustomerOrderDto(model.ProductId, model.Quantity);

        return dto;
    }
}