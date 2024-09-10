namespace Catalog.Domain.Entities;

public class Category : EntityBase
{
    public string Name { get; set; } = null!;
    public IEnumerable<Product> Products { get; set; } = new List<Product>();
}