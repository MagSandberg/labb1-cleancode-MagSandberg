using DataAccess.Models;
using Shared.DTOs;

namespace DataAccess.Repositories.Interfaces;

public interface ICustomerRepository
{
    Task<List<CustomerDto>> GetCustomers();
    Task<CustomerDto> GetCustomerByEmail(string email);
    Task<string> RegisterUser(CustomerDto customer);
    Task UpdateCustomer(CustomerDto customer);
    Task DeleteCustomer(Guid id);
}