using DataAccess.Models;
using DataAccess.Services.Mapping.Interfaces;
using Shared.DTOs;

namespace DataAccess.Services.Mapping;

public class ProductMapperProfile : IProductMapperProfiles
{
    public ProductModel MapToProductModel(ProductDto dto)
    {
        var model = new ProductModel(dto.Id, dto.Name, dto.Price, dto.Description);
        return model;
    }

    public ProductDto MapToProductDto(ProductModel model)
    {
        var dto = new ProductDto(model.ProductId, model.Name, model.Price, model.Description);
        return dto;
    }
}