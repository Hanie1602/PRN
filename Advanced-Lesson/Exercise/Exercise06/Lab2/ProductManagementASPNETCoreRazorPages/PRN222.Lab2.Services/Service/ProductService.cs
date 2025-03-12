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
			Product? p1 = _unitOfWork.ProductRepository.Entities
				.SingleOrDefault(c => c.ProductId == p.ProductId)
				?? throw new Exception("No products found");

			_unitOfWork.ProductRepository.Delete(p1.ProductId);
			_unitOfWork.Save();
		}

		public Product GetProductById(int id)
		{
			Product? product = _unitOfWork.ProductRepository
				.Entities
				.Include(p => p.Category)
				.FirstOrDefault(p => p.ProductId == id)
				?? throw new Exception("No products found");

			return product;
		}

		public List<Product> GetProducts(string? searchProductName, bool? sortByName, bool? sortByPrice)
		{
			IQueryable<Product> query = _unitOfWork.ProductRepository
				.Entities
				.Include(p => p.Category);

			//Lọc theo tên
			if (!string.IsNullOrWhiteSpace(searchProductName))
			{
				query = query.Where(p => p.ProductName.ToLower().Contains(searchProductName.Trim().ToLower()));
			}

			//Sắp xếp theo tên
			if (sortByName.HasValue)
			{
				query = sortByName.Value 
					? query.OrderBy(p => p.ProductName) 
					: query.OrderByDescending(p => p.ProductName);
			}
			
			//Sắp xếp theo giá
			if (sortByPrice.HasValue)
			{
				query = sortByPrice.Value 
					? query.OrderBy(p => p.UnitPrice) 
					: query.OrderByDescending(p => p.UnitPrice);
			}

			return query.ToList();
		}

		public void SaveProduct(Product p)
		{
			_unitOfWork.ProductRepository.Insert(p);
			_unitOfWork.Save();
		}

		public void UpdateProduct(Product p)
		{
			_unitOfWork.ProductRepository.Update(p);
			_unitOfWork.Save();
		}
	}
}
