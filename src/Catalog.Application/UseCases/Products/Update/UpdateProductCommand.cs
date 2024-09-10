using System.ComponentModel.DataAnnotations;
using Catalog.Application.Contracts;

namespace Catalog.Application.UseCases.Products.Update;

public class UpdateProductCommand : IRequest
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    [Range(0.1, double.MaxValue)]
    public decimal? Price { get; set; }
}