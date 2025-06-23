using Microsoft.AspNetCore.Mvc;
using ServicesAbstractions;
using Shared.Products;

namespace Presentation.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController(IServiceManager serviceManager) 
    : ControllerBase
{
    /// End Points
    /// Get All Products => IEnumerable<ProductResponse></ProductResponse>
    /// Get Product 
    /// Get All Brands
    /// Get All Types

    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<IEnumerable<ProductResponse>>>>
        GetAllProducts([FromQuery] ProductQueryParameters queryParameters)
    {
        throw new Exception("Test");  
        var products = await serviceManager.ProductService.GetAllProductsAsync(queryParameters);
        return Ok(products);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponse>> GetProduct(int id)
    {
        var product = await serviceManager.ProductService.GetProductAsync(id);
        return Ok(product);
    }
    [HttpGet("brands")]
    public async Task<ActionResult<IEnumerable<BrandResponse>>> GetBrands()
    {
        var brands = await serviceManager.ProductService.GetBrandsAsync();
        return Ok(brands);
    }
    [HttpGet("types")]
    public async Task<ActionResult<IEnumerable<TypeResponse>>> GetTypes()
    {
        var types = await serviceManager.ProductService.GetTypesAsync();
        return Ok(types);
    }

}
