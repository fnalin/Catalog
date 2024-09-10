using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Catalog.Application.Contracts;

namespace Catalog.Application.UseCases.Products.Create;

public class CreateProductCommand : IRequest
{
    [Required]
    public string? Name { get; set; }
    [Required]
    [Range(0.1, double.MaxValue)]
    public decimal Price { get; set; }
    [Required]
    public int? CategoryId { get; set; }
}