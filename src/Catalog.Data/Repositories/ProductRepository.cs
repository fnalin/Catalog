using Catalog.Domain.Contracts.Repositories;
using Catalog.Domain.Entities;
using Catalog.Domain.Exceptions.Domain;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Data.Repositories;

public sealed class ProductRepository(CatalogDbContext ctx) : GenericRepository<Product>(ctx), IProductRepository
{
    public override async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var data = await ctx.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        if (data is null) throw new EntityNotFoundException($"Product with id {id} not found");
        return data;
    }

    public override async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var data = await ctx.Products
             .Include(p => p.Category)
            .ToListAsync(cancellationToken);
        return data;
    }

    public Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}