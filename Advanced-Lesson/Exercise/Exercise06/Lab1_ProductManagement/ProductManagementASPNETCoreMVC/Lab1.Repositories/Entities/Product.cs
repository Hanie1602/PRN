using System.ComponentModel.DataAnnotations;

namespace Lab1.Repositories.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    [Display(Name = "Category")]
    public int CategoryId { get; set; }

    public short? UnitsInStock { get; set; }

    public decimal? UnitPrice { get; set; }

    public virtual Category? Category { get; set; } = null!;
}
