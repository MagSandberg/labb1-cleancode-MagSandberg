using Microsoft.AspNetCore.Mvc;
using DataAccess.Repositories.Interfaces;
using Shared.DTOs;

namespace Server.Controllers;

[ApiController]
[Route("/api")]
public class ProductController : ControllerBase
{
    private readonly IProductRespository _productRepository;

    public ProductController(IProductRespository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet("/products")]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productRepository.GetProducts();

        if (products.Count == 0) return NotFound("No products registered.");

        return Ok(products);
    }

    [HttpGet("/products/{id}")]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var product = await _productRepository.GetProduct(id);

        return Ok(product);
    }

    [HttpPost("/products/add")]
    public async Task<IActionResult> AddProduct(ProductDto productDto)
    {
        var result = await _productRepository.AddProduct(productDto);

        if (!result.Equals("Product added successfully.")) return BadRequest(result); 

        return Ok(result);
    }
}