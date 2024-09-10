using Catalog.Application.Contracts;

namespace Catalog.Application.UseCases.Products.Delete;

public class DeleteProductCommand (int id) : IRequest
{
    public int Id { get; set; } = id;
}