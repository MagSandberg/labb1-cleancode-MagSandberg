using DataAccess.Models;
using DataAccess.Services.Mapping.Interfaces;
using Shared.DTOs;

namespace DataAccess.Services.Mapping;

public class CustomerMapperProfile : ICustomerMapperProfile
{
    public CustomerModel MapToCustomerModel(CustomerDto dto)
    {
        var model = new CustomerModel(dto.Id, dto.FirstName, dto.LastName, dto.Email, dto.Password, new List<OrderModel>());

        return model;
    }

    public CustomerDto MapToCustomerDto(CustomerModel model)
    {
        var dto = new CustomerDto(model.CustomerId, model.FirstName, model.LastName, model.Email, model.Password, new List<OrderDto>());

        return dto;
    }
}