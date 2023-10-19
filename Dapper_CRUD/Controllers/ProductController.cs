using Dapper_CRUD.Business;
using Dapper_CRUD.DTOs.ProductDto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Dapper_CRUD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [Route("ProductList")]
    [SwaggerOperation(
        Summary = "Returns all products")]
    public async Task<IActionResult> ProductList()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }
    
    [HttpGet]
    [Route("GetProductById")]
    [SwaggerOperation(
        Summary = "Returns only one product by id")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _productService.GetProductById(id);
        return Ok(product);
    }
    
    
    [HttpPost]
    [Route("InsertProduct")]
    [SwaggerOperation(Summary = "Insert product to DB")]
    public async Task<IActionResult> InsertProduct(CreateProductDto product)
    {
        _productService.InsertProduct(product);
        return Ok("Product added!");
    }

    [HttpPut]
    [Route("UpdateProduct")]
    [SwaggerOperation(Summary = "Update product informations")]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto product)
    {
        _productService.UpdateProduct(product);
        return Ok("Product updated!");
    }

    [HttpDelete]
    [Route("DeleteProduct")]
    [SwaggerOperation(Summary = "Deletes product from DB")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        _productService.DeleteProduct(id);
        return Ok("Product deleted!");
    }
    
}