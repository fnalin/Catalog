namespace Catalog.Domain.Contracts.Infra;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken = default);
    Task RollbackAsync(CancellationToken cancellationToken = default);
}