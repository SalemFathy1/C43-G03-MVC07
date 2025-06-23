namespace Services.Specifications;
internal class ProductWithBrandAndTypeSpecifications
    : BaseSpecifications<Product>
{
    // Use this CTOR to create query to get product by id
    public ProductWithBrandAndTypeSpecifications(int id)
        : base(product => product.Id == id)
    {
        // Add Includes
        AddInclude(p => p.ProductBrand);
        AddInclude(p => p.ProductType);
    }
    // Use this CTOR to create query to get all products
    // Use for sorting & Filtration 
    public ProductWithBrandAndTypeSpecifications(ProductQueryParameters parameters)
        : base(CreateCriteria(parameters))
    {
        AddInclude(p => p.ProductBrand);
        AddInclude(p => p.ProductType);
        ApplySorting(parameters.Options);
        ApplyPagination(parameters.PageSize, parameters.PageIndex);

    }

    private void ApplySorting(ProductSortingOptions options)
    {
        switch (options)
        {
            case ProductSortingOptions.NameAsc:
                AddOrderBy(p => p.Name);
                break;
            case ProductSortingOptions.NameDesc:
                AddOrderByDescending(p => p.Name);
                break;
            case ProductSortingOptions.PriceAsc:
                AddOrderBy(p => p.Price);
                break;
            case ProductSortingOptions.PriceDesc:
                AddOrderByDescending(p => p.Price);
                break;
        }
    }

    private static System.Linq.Expressions.Expression<Func<Product, bool>> CreateCriteria(ProductQueryParameters parameters)
    {
        return product =>
        (!parameters.BrandId.HasValue) || (product.BrandId == parameters.BrandId.Value) &&
        (!parameters.TypeId.HasValue) || (product.TypeId == parameters.TypeId.Value) &&
        (string.IsNullOrWhiteSpace(parameters.Search) ||
        product.Name.ToLower().Contains(parameters.Search.ToLower()));
    }
}
