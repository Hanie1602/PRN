using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN222.Lab2.Repositories.Entities;
using PRN222.Lab2.Services.IService;

namespace PRN222.Lab2.RazorPages.Pages.Products
{
	public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public IList<Product> Product { get;set; } = default!;
		public int CurrentPage { get; set; } = 1;
		public int TotalPages { get; set; }

		public async Task<IActionResult> OnGet(string? searchProductName, string? sortOption, int? pageIndex, int pageSize = 10)
		{
			//Đọc Cookie xem User đã đăng nhập chưa
			if (Request.Cookies["Account"] == null)
			{
				return RedirectToPage("/Login");
			}

			//Xác định kiểu sắp xếp
			bool? sortByName = null;
			bool? sortByPrice = null;

			if (!string.IsNullOrEmpty(sortOption))
			{
				switch (sortOption)
				{
					case "name_asc":
						sortByName = true; break;
					case "name_desc":
						sortByName = false; break;
					case "price_asc":
						sortByPrice = true; break;
					case "price_desc":
						sortByPrice = false; break;
				}
			}

			//Lấy list Product có phân trang
			int totalProducts = _productService.GetTotalProducts(searchProductName);
			TotalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

			CurrentPage = pageIndex ?? 1;
			CurrentPage = Math.Max(1, Math.Min(CurrentPage, TotalPages)); //Giới hạn trong phạm vi hợp lệ

			Product = _productService.GetProducts(searchProductName, sortByName, sortByPrice, CurrentPage, pageSize);

			return Page();
		}

		public async Task<IActionResult> OnPostLogout()
		{
			Response.Cookies.Delete("UserId");
			Response.Cookies.Delete("Username");
			Response.Cookies.Delete("Account");

			return RedirectToPage("/Login");
		}

	}
}
