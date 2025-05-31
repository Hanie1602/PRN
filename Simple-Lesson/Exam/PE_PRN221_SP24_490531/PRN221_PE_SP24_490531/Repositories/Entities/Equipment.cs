using System.ComponentModel.DataAnnotations;

namespace Repositories.Entities
{
	public class Equipment
	{
		public int EqID { get; set; }

		[Required]
		public string EqCode { get; set; } = null!;

		[Required]
		[MinLength(10, ErrorMessage = "EqName must be at least 10 characters.")]
		[RegularExpression(@"^([A-Z][\w@#$&(,)]*\s?)+$", ErrorMessage = "Each word must begin with a capital letter and may contain letters, numbers, or @#$&().")]
		public string? EqName { get; set; }

		[Required]
		public string? Description { get; set; }

		[Required]
		public string? Model { get; set; }

		[Required]
		public string? SupplierName { get; set; }

		public DateTime? CreatedAt { get; set; }

		public DateTime? UpdatedAt { get; set; }

		[Required]
		[Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
		public int? Quantity { get; set; }

		[Required]
		public int? Status { get; set; }

		[Display(Name = "RoomName")]
		public int? RoomID { get; set; }

		[Display(Name = "RoomName")]
		public virtual Room? Rooms { get; set; } = null!;
	}
}
