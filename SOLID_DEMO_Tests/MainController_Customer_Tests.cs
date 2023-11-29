using DataAccess.Models;
using DataAccess.Services.Mapping.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SOLID_DEMO_Tests.Test_Interfaces;

namespace SOLID_DEMO_Tests
{
    public class MainControllerCustomerTests
    {
        public ICustomerMapperProfiles CustomerMapper = new CustomerMapperProfile();

        [Fact]
        public async Task MainController_RegisterUser_Return_Ok()
        {
            //Arrange

            var sut = await IMainControllerWithShopContext.CustomerInMemoryDb();
            var customer = new CustomerModel("dnd@dnd.com", "123", "Dnd", "Dndson");

            //Act

            var result = await sut.RegisterUser(CustomerMapper.MapToCustomerDto(customer));
            
            //Assert

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task MainController_GetCustomers_Return_ListOfCustomersObject()
        {
            //Arrange

            var sut = await IMainControllerWithShopContext.CustomerInMemoryDb();

            //Act

            var result = await sut.GetCustomers();

            //Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task MainController_GetCustomer_Return_CustomerObject()
        {
            //Arrange

            var sut = await IMainControllerWithShopContext.CustomerInMemoryDb();

            //Act

            var result = await sut.GetCustomer("ana@ana.com");

            //Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task MainController_LoginCustomer_Return_Ok()
        {
            //Arrange

            var sut = await IMainControllerWithShopContext.CustomerInMemoryDb();

            var customers = sut._shopContext.Customers.ToList();
            var customerPassword = customers[0].Password;
            var customerEmail = customers[0].Email;

            //Act

            var result = await sut.LoginCustomer(customerEmail, customerPassword);

            //Assert

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task MainController_LoginCustomer_Return_BadRequest()
        {
            //Arrange

            var sut = await IMainControllerWithShopContext.CustomerInMemoryDb();

            var customers = sut._shopContext.Customers.ToList();
            var customerPassword = new Guid();
            var customerEmail = customers[0].Email;

            //Act

            var result = await sut.LoginCustomer(customerEmail, customerPassword.ToString());

            //Assert

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task MainController_DeleteCustomer_Return_BadRequest()
        {
            //Arrange

            var sut = await IMainControllerWithShopContext.CustomerInMemoryDb();

            var customerId = new Guid();

            //Act

            var result = await sut.DeleteCustomer(customerId);

            //Assert

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task MainController_DeleteCustomer_Return_Ok()
        {
            //Arrange

            var sut = await IMainControllerWithShopContext.CustomerInMemoryDb();

            var newCustomer = new CustomerModel("ene@ene.com", "123", "Ene", "Eneson");
            var registerCustomer = await sut.RegisterUser(CustomerMapper.MapToCustomerDto(newCustomer));

            var customer = sut._shopContext.Customers.Where(c => c.Email == "ene@ene.com").ToList();

            //Act

            var result = await sut.DeleteCustomer(customer[0].CustomerId);

            //Assert

            Assert.IsType<OkResult>(result);
        }
    }
}