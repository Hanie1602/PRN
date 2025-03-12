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

		public async Task<IActionResult> OnGet(string? searchProductName, string? sortOption)
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

			Product = _productService.GetProducts(searchProductName, sortByName, sortByPrice);

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
