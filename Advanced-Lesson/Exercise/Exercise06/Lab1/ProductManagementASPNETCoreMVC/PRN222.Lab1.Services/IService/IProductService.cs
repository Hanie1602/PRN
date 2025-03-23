using PRN222.Lab1.Repositories.Entities;

namespace PRN222.Lab1.Services.IService
{
	public interface IProductService
	{
		void SaveProduct(Product p);

		void DeleteProduct(Product p);

		void UpdateProduct(Product p);

		List<Product> GetProducts();

		Product GetProductById(int id);
	}
}
