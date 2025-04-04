﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN222.Lab2.Repositories.Entities;
using PRN222.Lab2.Services.IService;

namespace PRN222.Lab2.RazorPages.Pages.Products
{
	public class DetailsModel : PageModel
    {
		private readonly IProductService _productService;

		public DetailsModel(IProductService productService)
        {
            _productService = productService;
        }

        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGet(int? id)
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
    }
}
