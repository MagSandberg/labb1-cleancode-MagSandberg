using DataAccess.Models;
using Shared.DTOs;

namespace DataAccess.Services.Mapping.Interfaces;

public interface ICustomerOrderMapper
{
    public CustomerOrderModel MapToCustomerOrderModel(CustomerOrderDto dto);
    public CustomerOrderDto MapToCustomerOrderDto(CustomerOrderModel model);
}