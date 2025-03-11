using Microsoft.EntityFrameworkCore;
using PRN222.Lab2.Repositories.Data;
using PRN222.Lab2.Repositories.Entities;
using PRN222.Lab2.Services.IService;

namespace PRN222.Lab2.Services.Service
{
	public class ProductService : IProductService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProductService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void DeleteProduct(Product p)
		{
			try
			{
				Product? p1 = _unitOfWork.GetRepository<Product>().Entities
					.SingleOrDefault(c => c.ProductId == p.ProductId);

				_unitOfWork.GetRepository<Product>().Delete(p1.ProductId);
				_unitOfWork.Save();
			}
			catch (Exception e)
			{
				Console.WriteLine($"Error Deleting product: {e.Message}");
			}
		}

		public Product GetProductById(int id)
		{
			Product? product = _unitOfWork.GetRepository<Product>()
				.Entities
				.Include(p => p.Category)
				.FirstOrDefault(p => p.ProductId == id)
				?? throw new Exception("No products found");

			return product;
		}

		public List<Product> GetProducts()
		{
			List<Product> listProducts = new List<Product>();
			try
			{
				listProducts = _unitOfWork.GetRepository<Product>()
					.Entities
					.Include(p => p.Category)
					.ToList();
			}
			catch (Exception e) { }
			return listProducts;
		}

		public void SaveProduct(Product p)
		{
			try
			{
				_unitOfWork.GetRepository<Product>().Insert(p);
				_unitOfWork.Save();
			}
			catch (Exception e)
			{
				Console.WriteLine($"Error Adding product: {e.Message}");
			}
		}

		public void UpdateProduct(Product p)
		{
			try
			{
				_unitOfWork.GetRepository<Product>().Update(p);
				_unitOfWork.Save();
			}
			catch (Exception e)
			{
				Console.WriteLine($"Error Updating product: {e.Message}");
			}
		}
	}
}
