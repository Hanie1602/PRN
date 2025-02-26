using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRN222.Lab1.Repositories.Entities;
using PRN222.Lab1.Services;

namespace PRN222.Lab1.MVC.Controllers
{
	public class ProductsController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;

		public ProductsController(IProductService productService, ICategoryService categoryService)
		{
			_productService = productService;
			_categoryService = categoryService;
		}

		#region Index
		// GET: Products
		public async Task<IActionResult> Index()
		{
			if (HttpContext.Session.GetString("UserId") == null)
			{
				//Chuyển đến trang đăng nhập hoặc thông báo lỗi
				return RedirectToAction("Login", "Account");
			}

			List<Product> myStoreDbContext = _productService.GetProducts();
			return View(myStoreDbContext.ToList());
		}
		#endregion

		#region Hiển thị thông tin chi tiết (Details)
		//GET: Products/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (HttpContext.Session.GetString("UserId") == null)
			{
				//Chuyển đến trang đăng nhập hoặc thông báo lỗi
				return RedirectToAction("Login", "Account");
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

			return View(product);
		}
		#endregion

		#region Tạo sản phẩm (Create)
		//GET: Products/Create
		public IActionResult Create()
		{
			if (HttpContext.Session.GetString("UserId") == null)
			{
				//Chuyển đến trang đăng nhập hoặc thông báo lỗi
				return RedirectToAction("Login", "Account");
			}

			ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "CategoryId", "CategoryName");
			return View();
		}
		
		//POST: Products/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ProductId, ProductName,CategoryId,UnitsInStock,UnitPrice")] Product product)
		{
			if (ModelState.IsValid)
			{
				_productService.SaveProduct(product);
				return RedirectToAction(nameof(Index));
			}

			ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "CategoryId", "CategoryName", product.CategoryId);

			return View(product);
		}
		#endregion

		#region Chính sửa thông tin sản phẩm (Edit)
		//GET: Products/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (HttpContext.Session.GetString("UserId") == null)
			{
				//Chuyển đến trang đăng nhập hoặc thông báo lỗi
				return RedirectToAction("Login", "Account");
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
			ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "CategoryId", "CategoryName", product.CategoryId);

			return View(product);
		}

		//POST: Products/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,CategoryId,UnitsInStock,UnitPrice")] Product product)
		{
			if (id != product.ProductId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_productService.UpdateProduct(product);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ProductExists(product.ProductId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}

			ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "CategoryId", "CategoryName", product.CategoryId);

			return View(product);
		}
		#endregion

		#region Xóa sản phẩm (Delete)
		//GET: Products/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (HttpContext.Session.GetString("UserId") == null)
			{
				//Chuyển đến trang đăng nhập hoặc thông báo lỗi
				return RedirectToAction("Login", "Account");
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

			return View(product);
		}

		//POST: Products/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			Product product = _productService.GetProductById((int)id);
			if (product != null)
			{
				_productService.DeleteProduct(product);
			}
			return RedirectToAction(nameof(Index));
		}

		private bool ProductExists(int id)
		{
			Product tmp = _productService.GetProductById(id);
			return (tmp != null) ? true : false;
		}
		#endregion

	}
}
