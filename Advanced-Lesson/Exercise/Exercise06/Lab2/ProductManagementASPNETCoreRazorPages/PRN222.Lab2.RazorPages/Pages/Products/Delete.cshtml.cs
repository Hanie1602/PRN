using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using PRN222.Lab2.Repositories.Entities;
using PRN222.Lab2.Services.IService;
using PRN222.Lab2.Services.Service;

namespace PRN222.Lab2.RazorPages.Pages.Products
{
	public class DeleteModel : PageModel
    {
		private readonly IProductService _productService;
		private readonly IHubContext<SignalrServer> _hubContext;

		public DeleteModel(IProductService productService, IHubContext<SignalrServer> hubContext)
        {
            _productService = productService;
            _hubContext = hubContext;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
			//Đọc Cookie xem User đã đăng nhập chưa
			if (Request.Cookies["Account"] == null)
			{
				return RedirectToPage("/Login");
			}

			if (id == null)
            {
                return NotFound();
            }

            Product product = _productService.GetProductById((int)id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
			//Đọc Cookie xem User đã đăng nhập chưa
			if (Request.Cookies["Account"] == null)
			{
				return RedirectToPage("/Login");
			}

			if (id == null)
            {
                return NotFound();
            }

            Product product = _productService.GetProductById((int)id);
			if (product != null)
            {
                Product = product;
                _productService.DeleteProduct(product);
				await _hubContext.Clients.All.SendAsync("LoadAllItems"); //Gửi tín hiệu cho All Client
			}

            return RedirectToPage("./Index");
        }
    }
}
