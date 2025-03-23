using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Entities;
using Services.IService;

namespace Equipments.Pages.Equipmentes
{
	public class IndexModel : PageModel
    {
		private readonly IEquipmentService _equipmentService;

		public IndexModel(IEquipmentService equipmentService)
		{
			_equipmentService = equipmentService;
		}

		public IList<Equipment> Equipment { get;set; } = default!;
		public int CurrentPage { get; set; } = 1;
		public int TotalPages { get; set; }

		public async Task<IActionResult> OnGet(string? eqName, int? quantity, string? sortOption, int? pageIndex, int pageSize = 5)
		{
			//Đọc Cookie xem User đã đăng nhập chưa
			if (Request.Cookies["Account"] == null)
			{
				return RedirectToPage("/Login");
			}

			#region Kiểm tra quyền cho Search
			//Kiểm tra role cho Search
			bool isSearching = !string.IsNullOrEmpty(eqName) && quantity.HasValue;

			string? role = Request.Cookies["Account"];

			if (isSearching && role != "1" && role != "2")
			{
				TempData["PermissionError"] = "You do not have permission to do this function!";
				return RedirectToPage("/Equipmentes/Index");
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
			int totalMedicine = _equipmentService.GetTotalEquipment(eqName, quantity);
			TotalPages = (int)Math.Ceiling((double)totalMedicine / pageSize);

			CurrentPage = pageIndex ?? 1;
			CurrentPage = Math.Max(1, Math.Min(CurrentPage, TotalPages));

			Equipment = _equipmentService
				.GetEquipment(eqName, quantity, sortByName, CurrentPage, pageSize);

			return Page();
		}

		public async Task<IActionResult> OnPostLogout()
		{
			Response.Cookies.Delete("FullName");
			Response.Cookies.Delete("Email");
			Response.Cookies.Delete("Account");

			return RedirectToPage("/Login");
		}
	}
}
