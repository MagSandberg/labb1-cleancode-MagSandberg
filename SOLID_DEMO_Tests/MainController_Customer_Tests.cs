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
        public void MainController_RegisterUser_Return_Ok()
        {
            //Arrange

            var sut = _mainController;

            //Act

            var result = sut.RegisterUser(new Customer("mag@email.com", "123")).Result;
            
            //Assert

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void MainController_GetCustomers_Return_ListOfCustomersObject()
        {
            //Arrange

            var sut = _mainController;

            //Act

            var result = sut.GetCustomers().Result;

            //Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void MainController_GetCustomer_Return_CustomerObject()
        {
            //Arrange

            var sut = _mainController;

            //Act

            var result = sut.GetCustomer("mag@email.com").Result;

            //Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void MainController_LoginCustomer_Return_Ok()
        {
            //Arrange

            var sut = _mainController;

            //Act

            var result = sut.LoginCustomer("mag@email.com", "123").Result;

            //Assert

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void MainController_LoginCustomer_Return_BadRequest()
        {
            //Arrange

            var sut = _mainController;

            //Act

            var result = sut.LoginCustomer("mag@email.com", "123456").Result;

            //Assert

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void MainController_DeleteCustomer_Return_BadRequest()
        {
            //Arrange

            var sut = _mainController;

            //Act

            var result = sut.DeleteCustomer(999).Result;

            //Assert

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void MainController_DeleteCustomer_Return_Ok()
        {
            //Arrange

            var sut = _mainController;

            //Act

            var result = sut.DeleteCustomer(51).Result;

            //Assert

            Assert.IsType<OkResult>(result);
        }
    }
}