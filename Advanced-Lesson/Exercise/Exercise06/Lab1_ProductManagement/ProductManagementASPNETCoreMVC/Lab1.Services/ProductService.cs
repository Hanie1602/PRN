using Microsoft.EntityFrameworkCore;
using PRN222.Lab1.Repositories;
using PRN222.Lab1.Repositories.Entities;

namespace PRN222.Lab1.Services
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
				_unitOfWork.GetRepository<Product>().Delete(p);
				_unitOfWork.Save();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error Deleting product: {ex.Message}");
			}
		}

		public void SaveProduct(Product p)
		{
			try
			{
				_unitOfWork.GetRepository<Product>().InsertAsync(p);
				_unitOfWork.Save();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error Adding product: {ex.Message}");
			}
		}

		public void UpdateProduct(Product p)
		{
			try
			{
				_unitOfWork.GetRepository<Product>().Update(p);	
				_unitOfWork.Save();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating product: {ex.Message}");
			}
		}

		public Product GetProductById(int id)
        {
			return _unitOfWork.GetRepository<Product>().Entities.Include(p => p.Category).FirstOrDefault(c => c.ProductId.Equals(id));
		}

        public List<Product> GetProducts()
        {
			List<Product> listProducts = new List<Product>();
			try
			{
				listProducts = _unitOfWork.GetRepository<Product>().Entities.Include(p => p.Category).ToList();
			}
			catch (Exception ex) { }
			return listProducts;
		}

    }
}
