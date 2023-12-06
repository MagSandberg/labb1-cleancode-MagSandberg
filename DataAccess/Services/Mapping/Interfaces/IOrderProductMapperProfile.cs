using DataAccess.Models;
using Shared.DTOs;

namespace DataAccess.Services.Mapping.Interfaces;

public interface IOrderProductMapperProfile
{
    public OrderProductModel MapToOrderProductModel(OrderProductDto dto);
    public OrderProductDto MapToOrderProductDto(OrderProductModel model);
}