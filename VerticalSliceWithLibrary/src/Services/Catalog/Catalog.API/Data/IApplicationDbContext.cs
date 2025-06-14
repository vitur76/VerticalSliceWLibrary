namespace Catalog.API.Data;
public interface IApplicationDbContext
{   DbSet<Product> Products { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}