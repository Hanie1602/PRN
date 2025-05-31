using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Entities;
using Services.IService;

namespace PharmaceuticalManagement.Pages.MedicineInformations
{
	public class IndexModel : PageModel
    {
		private readonly IMedicineInformationService _medicineInfoService;

		public IndexModel(IMedicineInformationService medicineInfoService)
		{
			_medicineInfoService = medicineInfoService;
		}

		public IList<MedicineInformation> MedicineInformation { get;set; } = default!;
		public int CurrentPage { get; set; } = 1;
		public int TotalPages { get; set; }

		public async Task<IActionResult> OnGet(string? activeIngredients, string? expirationDate, string? warnings, string? sortOption, int? pageIndex, int pageSize = 3)
		{
			//Đọc Cookie xem User đã đăng nhập chưa
			if (Request.Cookies["Account"] == null)
			{
				return RedirectToPage("/Login");
			}

			#region Kiểm tra quyền cho Search
			//Kiểm tra role cho Search
			bool isSearching = !string.IsNullOrEmpty(activeIngredients)
				|| !string.IsNullOrEmpty(expirationDate)
				|| !string.IsNullOrEmpty(warnings);

			string? role = Request.Cookies["Account"];

			if (isSearching && role != "2" && role != "3") // không phải Manager/Staff
			{
				TempData["PermissionError"] = "You do not have permission to do this function!";
				return RedirectToPage("/MedicineInformations/Index");
			}
			#endregion


			//Xác định kiểu sắp xếp
			bool? sortByName = null;

			if (!string.IsNullOrEmpty(sortOption))
			{
				switch (sortOption)
				{
					case "name_asc":
						sortByName = true; break;
					case "name_desc":
						sortByName = false; break;
				}
			}

			//Lấy list có phân trang
			int totalMedicine = _medicineInfoService.GetTotalMedicineInformations(activeIngredients, expirationDate, warnings);
			TotalPages = (int)Math.Ceiling((double)totalMedicine / pageSize);

			CurrentPage = pageIndex ?? 1;
			CurrentPage = Math.Max(1, Math.Min(CurrentPage, TotalPages));

			MedicineInformation = _medicineInfoService.GetMedicineInformations(activeIngredients, expirationDate, warnings, sortByName, CurrentPage, pageSize);

			return Page();
		}

		public async Task<IActionResult> OnPostLogout()
		{
			Response.Cookies.Delete("UserId");
			Response.Cookies.Delete("Email");
			Response.Cookies.Delete("Account");

			return RedirectToPage("/Login");
		}
	}
}
