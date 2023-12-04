﻿using DataAccess.Models;
using DataAccess.Services.Mapping.Interfaces;
using Shared.DTOs;

namespace DataAccess.Services.Mapping;

public class ProductMapperProfile : IProductMapperProfile
{
    public ProductModel MapToProductModel(ProductDto dto)
    {
        var model = new ProductModel(dto.Id, dto.Name, dto.Price, dto.Description, new List<OrderProductModel>());

        return model;
    }

    public ProductDto MapToProductDto(ProductModel model)
    {
        var dto = new ProductDto(model.ProductId, model.Name, model.Price, model.Description, new List<OrderProductDto>());

        return dto;
    }
}