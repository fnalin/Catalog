using Catalog.Domain.Contracts.Repositories;
using Catalog.Domain.Entities;
using Catalog.Domain.Exceptions.Domain;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Data.Repositories;

public class GenericRepository<TEntity> (CatalogDbContext ctx) : RepositoryBase, IGenericRepository<TEntity>
    where TEntity : EntityBase
{
    
    public virtual async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var data = await ctx.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
        if (data is null) 
            throw new EntityNotFoundException($"Entity {typeof(TEntity).Name} with id {id} not found");
        return data;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var data = await ctx.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);
        return data;
    }
    
    
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await ctx.Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        Task.FromResult(ctx.Set<TEntity>().Update(entity));

    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        Task.FromResult(ctx.Set<TEntity>().Remove(entity));

    
}