using Lab1.Repositories.Entities;

namespace PRN222.Lab1.Repositories
{
	public interface ICategoryRepository
    {
        List<Category> GetCategories();
    }
}
