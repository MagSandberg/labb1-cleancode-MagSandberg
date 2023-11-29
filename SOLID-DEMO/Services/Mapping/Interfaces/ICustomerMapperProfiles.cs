using DataAccess.Models;
using Shared.DTOs;

namespace Server.Services.Mapping.Interfaces;

public interface ICustomerMapperProfiles
{
    public CustomerModel MapToCustomerModel(CustomerDto dto);
    public CustomerDto MapToCustomerDto(CustomerModel model);
}