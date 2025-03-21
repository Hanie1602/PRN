using PRN222.Lab2.Repositories.Entities;

namespace PRN222.Lab2.Services.IService
{
	public interface IProductService
	{
		void SaveProduct(Product p);

		void DeleteProduct(Product p);

		void UpdateProduct(Product p);

		List<Product> GetProducts(string? searchProductName, bool? sortByName, bool? sortByPrice, int? pageIndex = null, int? pageSize = null);

		Product GetProductById(int id);

		int GetTotalProducts(string? searchProductName);
	}
}
