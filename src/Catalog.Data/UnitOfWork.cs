using Catalog.Domain.Contracts.Infra;

namespace Catalog.Data;

public class UnitOfWork (CatalogDbContext ctx) : IUnitOfWork
{
    public Task CommitAsync(CancellationToken cancellationToken = default) 
        => ctx.SaveChangesAsync(cancellationToken);

    public Task RollbackAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
}