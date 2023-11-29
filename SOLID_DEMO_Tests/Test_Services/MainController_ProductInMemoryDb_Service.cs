using Microsoft.EntityFrameworkCore;
using Server.Controllers;
using Server.DataAccess;
using Shared;

namespace SOLID_DEMO_Tests.Test_Services;

public class MainController_ProductInMemoryDb_Service
{
    //public static DbContextOptions _options = new DbContextOptionsBuilder<ShopContext>()
    //    .UseInMemoryDatabase(databaseName: "InMemory_ProductDb")
    //    .Options;
    //public static ShopContext _shopContext = new ShopContext(_options);
    //public static MainController _mainController = new MainController(_shopContext);

    //public async Task<MainController> ProductInMemoryDb()
    //{
    //    var mainController = _mainController;

    //    var prodOne = new Product { Name = "Apple", Description = "Apple Description" };
    //    var prodTwo = new Product { Name = "Banana", Description = "Banana Description" };
    //    var prodThree = new Product { Name = "Pear", Description = "Pear Description" };

    //    await mainController._shopContext.Products.AddRangeAsync(prodOne, prodTwo, prodThree);
    //    await mainController._shopContext.SaveChangesAsync();

    //    return mainController;
    //}
}