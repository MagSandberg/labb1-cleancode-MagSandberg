using DataAccess.Models;
using Shared.DTOs;

namespace DataAccess.Services.Mapping.Interfaces;

public interface IProductMapperProfiles
{
    public ProductModel MapToProductModel(ProductDto dto);
    public ProductDto MapToProductDto(ProductModel model);
}