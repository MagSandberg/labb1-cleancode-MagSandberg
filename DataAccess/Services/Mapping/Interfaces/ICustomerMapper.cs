using DataAccess.Models;
using Shared.DTOs;

namespace DataAccess.Services.Mapping.Interfaces;

public interface ICustomerMapper
{
    public CustomerModel MapToCustomerModel(CustomerDto dto);
    public CustomerDto MapToCustomerDto(CustomerModel model);
}