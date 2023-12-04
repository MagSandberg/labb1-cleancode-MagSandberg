using Shared.DTOs;

namespace DataAccess.UnitOfWork.Interfaces;

public interface IUnitOfWorkProduct
{
    Task<List<ProductDto>> GetProducts();
    Task<ProductDto> GetProduct(Guid id);
    Task<string> AddProduct(ProductDto product);
    Task<string> UpdateProduct(ProductDto product, Guid id);
    Task<string> DeleteProduct(Guid id);
}