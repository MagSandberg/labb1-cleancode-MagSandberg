using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Controllers;
using Server.DataAccess;
using Shared;

namespace SOLID_DEMO_Tests
{
    public class MainController_Customer_Tests
    {
        public static DbContextOptions _options = new DbContextOptionsBuilder<ShopContext>()
            .UseInMemoryDatabase(databaseName: "InMemory_CustomersDb")
            .Options;
        public static ShopContext _shopContext = new ShopContext(_options);
        public static MainController _mainController = new MainController(_shopContext);

        [Fact]
        public async Task MainController_RegisterUser_Return_Ok()
        {
            //Arrange

            var sut = _mainController;

            //Act

            var result = await sut.RegisterUser(new Customer("mag@email.com", "123"));
            
            //Assert

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task MainController_GetCustomers_Return_ListOfCustomersObject()
        {
            //Arrange

            var sut = _mainController;

            //Act

            var result = await sut.GetCustomers();

            //Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task MainController_GetCustomer_Return_CustomerObject()
        {
            //Arrange

            var sut = _mainController;

            //Act

            var result = await sut.GetCustomer("mag@email.com");

            //Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task MainController_LoginCustomer_Return_Ok()
        {
            //Arrange

            var sut = _mainController;

            //Act

            var result = await sut.LoginCustomer("mag@email.com", "123");

            //Assert

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task MainController_LoginCustomer_Return_BadRequest()
        {
            //Arrange

            var sut = _mainController;

            //Act

            var result = await sut.LoginCustomer("mag@email.com", "123456");

            //Assert

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task MainController_DeleteCustomer_Return_BadRequest()
        {
            //Arrange

            var sut = _mainController;

            //Act

            var result = await sut.DeleteCustomer(999);

            //Assert

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task MainController_DeleteCustomer_Return_Ok()
        {
            //Arrange

            var sut = _mainController;
            var newCustomer = sut.RegisterUser(new Customer("mag@email.com", "123"));

            //Act

            var result = await sut.DeleteCustomer(newCustomer.Id);

            //Assert

            Assert.IsType<OkResult>(result);
        }
    }
}