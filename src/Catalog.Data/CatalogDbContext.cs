using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Data;

public class CatalogDbContext (DbContextOptions<CatalogDbContext> options) : DbContext (options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
    }
}