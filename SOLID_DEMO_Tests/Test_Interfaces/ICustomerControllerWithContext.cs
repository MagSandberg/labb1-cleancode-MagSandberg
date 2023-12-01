using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using DataAccess.Services.Mapping;
using DataAccess.Services.Mapping.Interfaces;
using DataAccess.UnitOfWork;
using DataAccess.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using Server.Controllers;
using Server.DataAccess;
using SOLID_DEMO_Tests.Test_Services;

namespace SOLID_DEMO_Tests.Test_Interfaces;

public interface ICustomerControllerWithContext
{
    public static DbContextOptions _options = new DbContextOptionsBuilder<ShopContext>()
        .UseInMemoryDatabase(databaseName: "InMemoryDb")
        .Options;
    public static ShopContext _shopContext = new ShopContext(_options);

    public static ICustomerMapperProfile _customerMapperProfile = new CustomerMapperProfile();
    public static IUnitOfWorkCustomer _IUnitOfWorkCustomer = new UnitOfWorkCustomer(_shopContext, _customerMapperProfile);
    public static ICustomerRepository _ICustomerRepository = new CustomerRepository(_IUnitOfWorkCustomer);
    
    public static CustomerController _customerController = new CustomerController(_ICustomerRepository);

}