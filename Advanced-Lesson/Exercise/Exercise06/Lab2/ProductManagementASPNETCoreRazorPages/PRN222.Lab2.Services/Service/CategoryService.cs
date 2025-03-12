using PRN222.Lab2.Repositories.Data;
using PRN222.Lab2.Repositories.Entities;
using PRN222.Lab2.Services.IService;

namespace PRN222.Lab2.Services.Service
{
	public class CategoryService : ICategoryService
	{
		private readonly IUnitOfWork _unitOfWork;

		public CategoryService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public List<Category> GetCategories()
		{
			List<Category> listCategories = new List<Category>();
			listCategories = _unitOfWork.CategoryRepository.Entities.ToList();
			return listCategories;
		}

	}
}
