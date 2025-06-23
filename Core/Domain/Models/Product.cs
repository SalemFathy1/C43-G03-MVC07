namespace Domain.Models;
public class Product : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string PictureUrl { get; set; } = default!;
    public decimal Price { get; set; }
    public ProductBrand ProductBrand { get; set; } = default!; // Default => One To Many
    public int BrandId { get; set; } // FK
    public ProductType ProductType { get; set; } = default!; // Default => One To Many
    public int TypeId { get; set; } // FK

}

