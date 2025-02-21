using Lab1.Repositories.Entities;
using PRN222.Lab1.Repositories;

namespace PRN222.Lab1.Services
{
	public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService()
        {
            _repo = new CategoryRepository();
        }
        public List<Category> GetCategories() => _repo.GetCategories();
    }
}
