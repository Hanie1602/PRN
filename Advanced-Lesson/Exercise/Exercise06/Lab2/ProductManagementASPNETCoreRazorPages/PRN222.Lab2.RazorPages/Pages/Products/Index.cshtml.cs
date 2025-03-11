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

		public async Task<IActionResult> OnGet()
		{
			//Đọc Cookie xem User đã đăng nhập chưa
			if (Request.Cookies["Account"] != null)
			{
				Product = _productService.GetProducts();
				return Page();
			}

			return RedirectToPage("/Login");
		}

		public async Task<IActionResult> OnPostLogout()
		{
			Response.Cookies.Delete("Username");
			Response.Cookies.Delete("Account");

			return RedirectToPage("/Login");
		}

	}
}
