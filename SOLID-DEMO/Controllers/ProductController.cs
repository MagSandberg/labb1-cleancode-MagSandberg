using Microsoft.AspNetCore.Mvc;
using DataAccess.Repositories.Interfaces;
using Shared.DTOs;

namespace Server.Controllers;

[ApiController]
[Route("/api")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
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

        if (product.Id.Equals(Guid.Empty)) return NotFound(product);
        if (product.Name.Equals("Product does not exist.")) return NotFound(product);

        return Ok(product);
    }

    [HttpPost("/products/add")]
    public async Task<IActionResult> AddProduct(ProductDto productDto)
    {
        var result = await _productRepository.AddProduct(productDto);

        if (!result.Equals("Product added successfully.")) return BadRequest(result); 

        return Ok(result);
    }

    [HttpPut("/products/update")]
    public async Task<IActionResult> UpdateProduct(ProductDto productDto, Guid id)
    {
        var result = await _productRepository.UpdateProduct(productDto, id);

        if (result.Equals("Product does not exist.")) return BadRequest(result);

        return Ok(result);
    }

    [HttpDelete("/products/delete/{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var result = await _productRepository.DeleteProduct(id);

        if (result.Equals("Product does not exist.")) return BadRequest(result);

        return Ok(result);
    }
}