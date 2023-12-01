using DataAccess.Models;
using DataAccess.Services.Mapping.Interfaces;
using Shared.DTOs;

namespace DataAccess.Services.Mapping;

public class ProductCustomerMapperProfile : ICustomerMapperProfile
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