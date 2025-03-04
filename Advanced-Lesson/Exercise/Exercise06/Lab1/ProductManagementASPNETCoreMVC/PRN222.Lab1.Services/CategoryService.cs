using PRN222.Lab1.Repositories.Entities;
using PRN222.Lab1.Repositories;

namespace PRN222.Lab1.Services
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
			try
			{
				listCategories = _unitOfWork.GetRepository<Category>().Entities.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return listCategories;
		}

	}
}
