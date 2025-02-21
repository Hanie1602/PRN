using Lab1.Repositories;
using Lab1.Repositories.Entities;

namespace PRN222.Lab1.Repositories
{
	public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                using var context = new MyStoreDbContext();
                categories = context.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categories;
        }
    }
}
