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
