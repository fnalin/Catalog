using Catalog.Application.Contracts;

namespace Catalog.Application.UseCases.Products.GetById;

public class GetByIdProductQuery (int id) : IRequest
{
    public int Id { get; set; } = id;
}