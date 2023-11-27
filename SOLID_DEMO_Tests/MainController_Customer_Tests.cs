using Microsoft.AspNetCore.Mvc;
using Shared;
using SOLID_DEMO_Tests.Test_Services;

namespace SOLID_DEMO_Tests
{
    public class MainControllerCustomerTests
    {
        private static readonly MainController_CustomerInMemoryDb_Service CustomerInMemoryDbService = new();

        [Fact]
        public async Task MainController_RegisterUser_Return_Ok()
        {
            //Arrange

            var sut = await CustomerInMemoryDbService.CustomerInMemoryDb();

            //Act

            var result = await sut.RegisterUser(new Customer("mag@email.com", "123"));
            
            //Assert

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task MainController_GetCustomers_Return_ListOfCustomersObject()
        {
            //Arrange

            var sut = await CustomerInMemoryDbService.CustomerInMemoryDb();

            //Act

            var result = await sut.GetCustomers();

            //Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task MainController_GetCustomer_Return_CustomerObject()
        {
            //Arrange

            var sut = await CustomerInMemoryDbService.CustomerInMemoryDb();

            //Act

            var result = await sut.GetCustomer("hej@gimajl.com");

            //Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task MainController_LoginCustomer_Return_Ok()
        {
            //Arrange

            var sut = await CustomerInMemoryDbService.CustomerInMemoryDb();
            var customer = sut._shopContext.Customers.FirstOrDefault(c => c.Id == 1);

            //Act

            var result = await sut.LoginCustomer(customer.Name, customer.Password);

            //Assert

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task MainController_LoginCustomer_Return_BadRequest()
        {
            //Arrange

            var sut = await CustomerInMemoryDbService.CustomerInMemoryDb();
            var customer = sut._shopContext.Customers.FirstOrDefault(c => c.Id == 1);
            var wrongPassword = "235345346";

            //Act

            var result = await sut.LoginCustomer(customer.Name, wrongPassword);

            //Assert

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task MainController_DeleteCustomer_Return_BadRequest()
        {
            //Arrange

            var sut = await CustomerInMemoryDbService.CustomerInMemoryDb();

            //Act

            var result = await sut.DeleteCustomer(999);

            //Assert

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task MainController_DeleteCustomer_Return_Ok()
        {
            //Arrange

            var sut = await CustomerInMemoryDbService.CustomerInMemoryDb();
            var newCustomer = sut.RegisterUser(new Customer("mag@email.com", "123"));

            //Act

            var result = await sut.DeleteCustomer(newCustomer.Id);

            //Assert

            Assert.IsType<OkResult>(result);
        }
    }
}