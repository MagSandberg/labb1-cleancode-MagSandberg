using DataAccess.Models;
using Server.Services.Mapping.Interfaces;
using Shared.DTOs;

namespace Server.Services.Mapping;

public class ProductCustomerMapperProfile : ICustomerMapperProfiles
{
    public CustomerModel MapToCustomerModel(CustomerDto dto)
    {
        throw new NotImplementedException();
    }

    public CustomerDto MapToCustomerDto(CustomerModel model)
    {
        throw new NotImplementedException();
    }
}