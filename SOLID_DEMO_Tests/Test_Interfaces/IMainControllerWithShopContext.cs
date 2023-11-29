using Microsoft.EntityFrameworkCore;
using Server.Controllers;
using Server.DataAccess;
using SOLID_DEMO_Tests.Test_Services;

namespace SOLID_DEMO_Tests.Test_Interfaces;

public interface IMainControllerWithShopContext
{
    public static DbContextOptions _options = new DbContextOptionsBuilder<ShopContext>()
        .UseInMemoryDatabase(databaseName: "InMemoryDb")
        .Options;
    public static ShopContext _shopContext = new ShopContext(_options);
    public static MainController _mainController = new MainController(_shopContext);

    public static MainController_CustomerInMemoryDb_Service _customerInMemoryDb = new MainController_CustomerInMemoryDb_Service();

    public static async Task<MainController> CustomerInMemoryDb()
    {
        return await _customerInMemoryDb.CustomerInMemoryDb();
    }

    //public static async Task<MainController> ProductInMemoryDb()
    //{
    //    return await _customerInMemoryDb.ProductInMemoryDb();
    //}

    //public static async Task<MainController> OrderInMemoryDb()
    //{
    //    return await _customerInMemoryDb.OrderInMemoryDb();
    //}
}