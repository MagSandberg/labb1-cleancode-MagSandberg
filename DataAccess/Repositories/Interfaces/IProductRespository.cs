using Shared.DTOs;

namespace DataAccess.Repositories.Interfaces;

public interface IProductRespository
{
    Task<List<ProductDto>> GetProducts();
    Task<ProductDto> GetProduct(Guid id);
    Task<string> AddProduct(ProductDto product);
}