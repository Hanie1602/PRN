using System.ComponentModel.DataAnnotations;

namespace Repositories.Entities
{
	public class MedicineInformation
	{
		public string MedicineID { get; set; } = null!;

		[Required]
		public string MedicineName { get; set; } = null!;

		[Required]
		[MinLength(10, ErrorMessage = "ActiveIngredients must be at least 10 characters.")]
		[RegularExpression(@"^([A-Z0-9][a-zA-Z0-9]*(\s)?)+$",
		ErrorMessage = "Each word in ActiveIngredients must start with an uppercase letter or number and contain no special characters (#, @, &, (, )).")]
		public string ActiveIngredients { get; set; } = null!;

		[Required]
		public string? ExpirationDate { get; set; }

		[Required]
		public string DosageForm {  get; set; } = null!;

		[Required]
		public string WarningsAndPrecautions { get; set; } = null!;

		[Required]
		[Display(Name = "Manufacturer")]
		public string ManufacturerID { get; set; } = null!;

		[Display(Name = "ManufacturerName")]
		public virtual Manufacturer? Manufacturer { get; set; } = null!;
	}
}

/* Note
 ^: bắt đầu chuỗi
 [A-Z0-9]: Ký tự đầu tiên của mỗi từ là chữ in hoa hoặc số
 [a-zA-Z0-9]*: Các ký tự còn lại là chữ/số (không cho phép ký tự đặc biệt)
 (\s)?: Cho phép khoảng trắng giữa các từ
 +: Lặp lại cho nhiều từ
 $: Kết thúc chuỗi
 */

