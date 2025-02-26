using PRN222.Lab1.Repositories;
using PRN222.Lab1.Repositories.Entities;

namespace PRN222.Lab1.Services
{
	public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService()
        {
            _repository = new ProductRepository();
        }

        public void DeleteProduct(Product p)
        {
            _repository.DeleteProduct(p);
        }

		public void SaveProduct(Product p)
		{
			_repository.SaveProduct(p);
		}

		public void UpdateProduct(Product p)
		{
			_repository.UpdateProduct(p);
		}

		public Product GetProductById(int id)
        {
            return _repository.GetProductById(id);
        }

        public List<Product> GetProducts()
        {
            return _repository.GetProducts();
        }

    }
}
