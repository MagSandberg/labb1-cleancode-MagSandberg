using Microsoft.AspNetCore.Mvc;
using Server.Controllers;
using Server.DataAccess;
using Shared;
using SOLID_DEMO_Tests.Test_Services;

namespace SOLID_DEMO_Tests
{
    public class MainControllerCustomerTests
    {
        private static readonly MainController_InMemoryDb_Service InMemoryDbService = new();

        [Fact]
        public async Task MainController_RegisterUser_Return_Ok()
        {
            //Arrange

            var sut = await InMemoryDbService.CustomerInMemoryDb();

            //Act

            var result = await sut.RegisterUser(new Customer("mag@email.com", "123"));
            
            //Assert

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task MainController_GetCustomers_Return_ListOfCustomersObject()
        {
            //Arrange

            var sut = await InMemoryDbService.CustomerInMemoryDb();

            //Act

            var result = await sut.GetCustomers();

            //Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task MainController_GetCustomer_Return_CustomerObject()
        {
            //Arrange

            var sut = await InMemoryDbService.CustomerInMemoryDb();

            //Act

            var result = await sut.GetCustomer("hej@gimajl.com");

            //Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task MainController_LoginCustomer_Return_Ok()
        {
            //Arrange

            var sut = await InMemoryDbService.CustomerInMemoryDb();

            //Act

            var result = await sut.LoginCustomer("hej@gimajl.com", "123");

            //Assert

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task MainController_LoginCustomer_Return_BadRequest()
        {
            //Arrange

            var sut = await InMemoryDbService.CustomerInMemoryDb();

            //Act

            var result = await sut.LoginCustomer("hej@gimajl.com", "123456");

            //Assert

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task MainController_DeleteCustomer_Return_BadRequest()
        {
            //Arrange

            var sut = await InMemoryDbService.CustomerInMemoryDb();

            //Act

            var result = await sut.DeleteCustomer(999);

            //Assert

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task MainController_DeleteCustomer_Return_Ok()
        {
            //Arrange

            var sut = await InMemoryDbService.CustomerInMemoryDb();
            var newCustomer = sut.RegisterUser(new Customer("mag@email.com", "123"));

            //Act

            var result = await sut.DeleteCustomer(newCustomer.Id);

            //Assert

            Assert.IsType<OkResult>(result);
        }
    }
}