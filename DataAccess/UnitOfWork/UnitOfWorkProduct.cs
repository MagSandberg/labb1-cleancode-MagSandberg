using DataAccess.Contexts;
using DataAccess.Services.Mapping.Interfaces;
using DataAccess.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;

namespace DataAccess.UnitOfWork;

public class UnitOfWorkProduct : IUnitOfWorkProduct
{
    private readonly ShopContext _shopContext;
    private readonly IProductMapperProfile _productMapper;

    public UnitOfWorkProduct(ShopContext shopContext, IProductMapperProfile productMapper)
    {
        _shopContext = shopContext;
        _productMapper = productMapper;
    }


    public async Task<List<ProductDto>> GetProducts()
    {
        var products = await _shopContext.Products.ToListAsync();

        if (products.Count == 0)
        {
            return new List<ProductDto>();
        }

        return products.Select(product => _productMapper.MapToProductDto(product)).ToList();
    }

    public async Task<ProductDto> GetProduct(Guid id)
    {
        var product = await _shopContext.Products.FirstOrDefaultAsync(p => p.ProductId.Equals(id));

        if (product == null)
        {
            return new ProductDto("Product does not exist.", 0, "");
        }

        return _productMapper.MapToProductDto(product);
    }

    public async Task<string> AddProduct(ProductDto product)
    {
        var productExists = await _shopContext.Products.FirstOrDefaultAsync(p => p.Name.Equals(product.Name));
        if (productExists is not null) return "Product already exists.";

        await _shopContext.Products.AddAsync(_productMapper.MapToProductModel(product));

        var result = await _shopContext.SaveChangesAsync();

        return result > 0 ? "Product added successfully." : "Failed to add product.";
    }

    public async Task<string> UpdateProduct(ProductDto product, Guid id)
    {
        var productExists = await _shopContext.Products.FirstOrDefaultAsync(p => p.ProductId.Equals(product.Id));
        if (productExists is null) return "Product does not exist.";

        productExists.Name = product.Name;
        productExists.Price = product.Price;
        productExists.Description = product.Description;

        var result = await _shopContext.SaveChangesAsync();

        return result > 0 ? "Product updated successfully" : "Failed to update product.";
    }

    public async Task<string> DeleteProduct(Guid id)
    {
        var productExists = await _shopContext.Products.FirstOrDefaultAsync(p => p.ProductId.Equals(id));
        if (productExists is null) return "Product does not exist.";

        _shopContext.Products.Remove(productExists);
        var result = await _shopContext.SaveChangesAsync();

        return result > 0 ? "Product deleted successfully." : "Failed to delete product.";
    }
}