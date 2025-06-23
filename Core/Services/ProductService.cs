using Domain.Exceptions;
using Services.Specifications;
namespace Services;

internal class ProductService(IUnitOfWork unitOfWork, IMapper mapper) 
    : IProductService
{
    public async Task<PaginatedResponse<ProductResponse>> GetAllProductsAsync(ProductQueryParameters queryParameters)
    {
        var specifications = new ProductWithBrandAndTypeSpecifications(queryParameters);   
        var products = await unitOfWork.GetRepository<Product, int>().GetAllAsync(specifications);
        var data = mapper.Map<IEnumerable<Product>, IEnumerable<ProductResponse>>(products);  
        var pageCount = data.Count();
        var totalCount = await unitOfWork.GetRepository<Product, int>()
            .CountAsync(new ProductCountSpecifiactions(queryParameters));
        return new(queryParameters.PageIndex, pageCount, totalCount, data);
    }


    public async Task<ProductResponse> GetProductAsync(int id)
    {
        var specifications = new ProductWithBrandAndTypeSpecifications(id);
        var product = await unitOfWork.GetRepository<Product, int>().GetAsync(specifications) ??
            throw new ProductNotFoundException(id); // Handling Product When it will be NULL
        return mapper.Map<Product, ProductResponse>(product);
    }
    public async Task<IEnumerable<BrandResponse>> GetBrandsAsync()
    {
        var brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
        return mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandResponse>>(brands);
    }

    public async Task<IEnumerable<TypeResponse>> GetTypesAsync()
    {
        var types = await unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
        return mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeResponse>>(types);
    }

}
