using Shared.DTOs;

namespace DataAccess.UnitOfWork.Interfaces;

public interface IUnitOfWorkCustomer
{
    Task<List<CustomerDto>> GetCustomers();
    Task<CustomerDto> GetCustomerByEmail(string email);
    Task<string> RegisterUser(CustomerDto customer);
    Task<string> UpdateCustomer(CustomerDto customer, Guid id);
    Task<string> LoginCustomer(string email, string password);
    Task<string> DeleteCustomer(Guid id);
}