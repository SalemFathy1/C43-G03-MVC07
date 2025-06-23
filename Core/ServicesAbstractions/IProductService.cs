using Shared.Products;
namespace ServicesAbstractions;
public interface IProductService
{
    Task<PaginatedResponse<ProductResponse>> GetAllProductsAsync(ProductQueryParameters queryParameters);
    Task<ProductResponse> GetProductAsync(int id);
    Task<IEnumerable<BrandResponse>> GetBrandsAsync();
    Task<IEnumerable<TypeResponse>> GetTypesAsync();
}

