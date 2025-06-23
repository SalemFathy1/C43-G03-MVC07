namespace Persistence.Data;
public class StoredDbContext(DbContextOptions<StoredDbContext> options) : DbContext(options) // Chaining 
{
    public DbSet<Product> Products { get; set; }  
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(Persistence.AssemblyReference).Assembly); 


    // Open-Closed 
}
