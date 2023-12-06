using DataAccess.Models;
using DataAccess.Services.Mapping.Interfaces;
using Shared.DTOs;

namespace DataAccess.Services.Mapping;

public class CustomerMapper : ICustomerMapper
{
    public CustomerModel MapToCustomerModel(CustomerDto dto)
    {
        var model = new CustomerModel(dto.FirstName, dto.LastName, dto.Email, dto.Password)
        {
            CustomerId = dto.Id
        };

        return model;
    }

    public CustomerDto MapToCustomerDto(CustomerModel model)
    {
        var dto = new CustomerDto(model.FirstName, model.LastName, model.Email, model.Password)
        {
            Id = model.CustomerId
        };

        return dto;
    }
}