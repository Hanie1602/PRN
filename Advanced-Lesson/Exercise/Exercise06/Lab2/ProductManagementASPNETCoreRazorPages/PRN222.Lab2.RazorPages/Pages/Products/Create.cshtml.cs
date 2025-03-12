using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using PRN222.Lab2.Repositories.Entities;
using PRN222.Lab2.Services.IService;
using PRN222.Lab2.Services.Service;

namespace PRN222.Lab2.RazorPages.Pages.Products
{
	public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
		private readonly IHubContext<SignalrServer> _hubContext;

		public CreateModel(IProductService productService, ICategoryService categoryService, IHubContext<SignalrServer> hubContext)
        {
            _productService = productService;
            _categoryService = categoryService;
            _hubContext = hubContext;
        }

        public IActionResult OnGet()
        {
			//Đọc Cookie xem User đã đăng nhập chưa
			if (Request.Cookies["Account"] == null)
			{
				return RedirectToPage("/Login");
			}

			ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "CategoryId", "CategoryName");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
			//Đọc Cookie xem User đã đăng nhập chưa
			if (Request.Cookies["Account"] == null)
			{
				return RedirectToPage("/Login");
			}

			if (!ModelState.IsValid)
            {
                return Page();
            }

            _productService.SaveProduct(Product);
			await _hubContext.Clients.All.SendAsync("LoadAllItems"); //Gửi tín hiệu cho All Client

			return RedirectToPage("./Index");
        }
    }
}
