using DataAccess.Models;
using Shared.DTOs;

namespace Server.Services.Mapping.Interfaces;

public interface IProductMapperProfiles
{
    public ProductModel MapToCustomerModel(ProductDto dto);
    public ProductDto MapToCustomerDto(ProductModel model);
}