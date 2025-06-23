namespace Shared.Products;

// C# 9.0
// record => Reference Type
// Equals => Based On Value

// record Test(int id); // id => Property(set; init;)
public record ProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PictureUrl { get; set; }
    public decimal Price { get; set; }  
    public string BrandName { get; set; }
    public string TypeName { get; set; }
}
