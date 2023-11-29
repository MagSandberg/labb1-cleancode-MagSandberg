using DataAccess.Models;
using Server.Services.Mapping.Interfaces;
using Shared.DTOs;

namespace Server.Services.Mapping;

public class CustomerMapperProfile : ICustomerMapperProfiles
{
    public CustomerModel MapToCustomerModel(CustomerDto dto)
    {
        var model = new CustomerModel(dto.Email, dto.Password, dto.FirstName, dto.LastName);
        return model;
    }

    public CustomerDto MapToCustomerDto(CustomerModel model)
    {
        var dto = new CustomerDto(model.Email, model.Password, model.FirstName, model.LastName);
        return dto;
    }
}
