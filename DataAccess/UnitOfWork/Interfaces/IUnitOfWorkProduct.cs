using Shared.DTOs;

namespace DataAccess.UnitOfWork.Interfaces;

public interface IUnitOfWorkProduct
{
    Task<List<ProductDto>> GetProducts();
    Task<ProductDto> GetProduct(Guid id);
    Task<string> AddProduct(ProductDto product);
    Task<ProductDto> UpdateProduct(ProductDto product);
    Task<string> DeleteProduct(Guid id);
}