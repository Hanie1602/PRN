using System.ComponentModel.DataAnnotations;

namespace PRN231_SU25_SE171916.Repositories.Models;

public partial class Handbag
{
    public int HandbagId { get; set; }

    public int? BrandId { get; set; }

	[Required(ErrorMessage = "Model Name is required.")]
	[RegularExpression(@"^([A-Z0-9][a-zA-Z0-9#]*\s)*([A-Z0-9][a-zA-Z0-9#]*)$",
	ErrorMessage = "Each word must start with a capital letter or digit and contain only letters, digits, spaces or #.")]
	public string ModelName { get; set; } = null!;

    public string? Material { get; set; }

    public string? Color { get; set; }

	[Range(0, int.MaxValue, ErrorMessage = "Price must be > 0.")]
	public decimal? Price { get; set; }

	[Range(0, int.MaxValue, ErrorMessage = "Stock must be > 0.")]
	public int? Stock { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public virtual Brand? Brand { get; set; }
}
