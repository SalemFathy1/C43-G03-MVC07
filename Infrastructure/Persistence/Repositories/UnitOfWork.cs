namespace Persistence.Repositories;
public class UnitOfWork(StoredDbContext context)
    : IUnitOfWork
{
    private readonly Dictionary<string/*typeName*/, object/*Repo*/> _repositories = [];

    public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
        where TEntity : BaseEntity<TKey>
    {
        var typeName = typeof(TEntity).Name;
        // Get repo from the container
        if (_repositories.ContainsKey(typeName))
            return (IGenericRepository<TEntity, TKey>)_repositories[typeName]; // Casting

        var repo = new GenericRepository<TEntity, TKey>(context);
        _repositories[typeName] = repo; // Add to the container
        return repo;
    }
    public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();
}
