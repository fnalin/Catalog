using Catalog.Domain.Contracts.Repositories;
using Catalog.Domain.Entities;

namespace Catalog.Data.Repositories;

public sealed class CategoryRepository(CatalogDbContext ctx) : GenericRepository<Category>(ctx), ICategoryRepository;