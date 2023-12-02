using DataAccess.Repositories.Interfaces;
using DataAccess.UnitOfWork.Interfaces;
using Shared.DTOs;

namespace DataAccess.Repositories;

public class ProductRepository : IProductRespository
{
    private readonly IUnitOfWorkProduct _unitOfWorkProduct;

    public ProductRepository(IUnitOfWorkProduct unitOfWorkProduct)
    {
        _unitOfWorkProduct = unitOfWorkProduct;
    }

    public async Task<List<ProductDto>> GetProducts()
    {
        var products = await _unitOfWorkProduct.GetProducts();

        return products.ToList();
    }

    public async Task<ProductDto> GetProduct(Guid id)
    {
        var product = await _unitOfWorkProduct.GetProduct(id);

        return product;
    }

    public async Task<string> AddProduct(ProductDto product)
    {
        var result = await _unitOfWorkProduct.AddProduct(product);

        return result;
    }
}