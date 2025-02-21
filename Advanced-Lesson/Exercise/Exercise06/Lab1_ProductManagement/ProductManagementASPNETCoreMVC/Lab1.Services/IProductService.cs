using Lab1.Repositories.Entities;

namespace PRN222.Lab1.Services
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
