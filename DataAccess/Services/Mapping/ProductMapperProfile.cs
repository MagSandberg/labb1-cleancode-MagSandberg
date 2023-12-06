using DataAccess.Models;
using DataAccess.Services.Mapping.Interfaces;
using Shared.DTOs;

namespace DataAccess.Services.Mapping;

public class ProductMapperProfile : IProductMapperProfile
{
    public ProductModel MapToProductModel(ProductDto dto)
    {
        var model = new ProductModel(dto.Name, dto.Price, dto.Description)
        {
            ProductId = dto.Id
        };

        return model;
    }

    public ProductDto MapToProductDto(ProductModel model)
    {
        var dto = new ProductDto(model.Name, model.Price, model.Description)
        {
            Id = model.ProductId
        };

        return dto;
    }
}