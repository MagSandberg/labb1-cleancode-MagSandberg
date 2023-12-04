using Shared.DTOs;

namespace DataAccess.Repositories.Interfaces;

public interface IProductRepository
{
    Task<List<ProductDto>> GetProducts();
    Task<ProductDto> GetProduct(Guid id);
    Task<string> AddProduct(ProductDto product);
    Task<string> UpdateProduct(ProductDto product, Guid id);
    Task<string> DeleteProduct(Guid id);
}