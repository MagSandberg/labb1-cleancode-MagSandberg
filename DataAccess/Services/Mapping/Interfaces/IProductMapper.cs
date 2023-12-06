using DataAccess.Models;
using Shared.DTOs;

namespace DataAccess.Services.Mapping.Interfaces;

public interface IProductMapper
{
    public ProductModel MapToProductModel(ProductDto dto);
    public ProductDto MapToProductDto(ProductModel model);
}