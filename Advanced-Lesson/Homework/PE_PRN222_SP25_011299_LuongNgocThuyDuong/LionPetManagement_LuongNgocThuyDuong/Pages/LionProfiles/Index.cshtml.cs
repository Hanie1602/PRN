using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Entities;
using Services.IService;

namespace LionPetManagement_LuongNgocThuyDuong.Pages.LionProfiles
{
	public class IndexModel : PageModel
    {
		private readonly ILionProfileService _lionProfileService;

		public IndexModel(ILionProfileService lionProfileService)
		{
			_lionProfileService = lionProfileService;
		}

		public IList<LionProfile> LionProfile { get;set; } = default!;
		public int CurrentPage { get; set; } = 1;
		public int TotalPages { get; set; }

		public async Task<IActionResult> OnGetAsync(string? sortOption, int? pageIndex, int pageSize = 5)
		{
			//Đọc Cookie xem User đã đăng nhập chưa
			if (Request.Cookies["Account"] == null)
			{
				return RedirectToPage("/Login");
			}

			#region Kiểm tra quyền cho Search
			////Kiểm tra role cho Search
			//bool isSearching = !string.IsNullOrEmpty(eqName) && quantity.HasValue;

			//string? role = Request.Cookies["Account"];

			//if (isSearching && role != "1" && role != "2")
			//{
			//	TempData["PermissionError"] = "You do not have permission to do this function!";
			//	return RedirectToPage("/Equipmentes/Index");
			//}
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
			//int totalMedicine = _lionProfileService.GetTotalLionProfile();
			//TotalPages = (int)Math.Ceiling((double)totalMedicine / pageSize);

			CurrentPage = pageIndex ?? 1;
			CurrentPage = Math.Max(1, Math.Min(CurrentPage, TotalPages));

			LionProfile = _lionProfileService
				.GetLionProfile(sortByName, CurrentPage, pageSize);

			return Page();
		}

		public async Task<IActionResult> OnPostLogout()
		{
			Response.Cookies.Delete("Username");
			Response.Cookies.Delete("Email");
			Response.Cookies.Delete("Account");

			return RedirectToPage("/Login");
		}

	}
}
