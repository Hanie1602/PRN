using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PRN222.Lab2.RazorPages.Hubs;
using PRN222.Lab2.Repositories.Entities;
using PRN222.Lab2.Services.IService;

namespace PRN222.Lab2.RazorPages.Pages.Products
{
	public class EditModel : PageModel
    {
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;
		private readonly IHubContext<SignalrServer> _hubContext;

		public EditModel(IProductService productService, ICategoryService categoryService, IHubContext<SignalrServer> hubContext)
        {
            _productService = productService;
            _categoryService = categoryService;
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

            var product = _productService.GetProductById((int)id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;
           ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "CategoryId", "CategoryName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
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

            try
            {
                _productService.UpdateProduct(Product);
				await _hubContext.Clients.All.SendAsync("LoadAllItems"); //Gửi tín hiệu cho All Client
			}
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
            return (_productService.GetProductById(id) == null) ? true : false;
        }
    }
}
