using DataAccess.Services.Mapping.Interfaces;
using DataAccess.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using Server.DataAccess;
using Shared.DTOs;

namespace DataAccess.UnitOfWork;

public class UnitOfWorkProduct : IUnitOfWorkProduct
{
    private readonly ShopContext _shopContext;
    private readonly IProductMapperProfiles _productMapper;

    public UnitOfWorkProduct(ShopContext shopContext, IProductMapperProfiles productMapper)
    {
        _shopContext = shopContext;
        _productMapper = productMapper;
    }


    public async Task<List<ProductDto>> GetProducts()
    {
        var products = await _shopContext.Products.ToListAsync();

        return products.Select(product => _productMapper.MapToProductDto(product)).ToList();
    }

    public async Task<ProductDto> GetProduct(Guid id)
    {
        var product = await _shopContext.Products.FirstOrDefaultAsync(p => p.ProductId.Equals(id));

        if (product == null)
        {
            return new ProductDto(Guid.Empty, "Product does not exist.", 0, "");
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
}