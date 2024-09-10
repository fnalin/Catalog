namespace Catalog.Domain.Entities;

public class Product : EntityBase
{
    public Product() {}
    public Product(string name, decimal price, int categoryId)
    {
        Name = name;
        Price = price;
        CategoryId = categoryId;
    }

    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }

    public void Update(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}