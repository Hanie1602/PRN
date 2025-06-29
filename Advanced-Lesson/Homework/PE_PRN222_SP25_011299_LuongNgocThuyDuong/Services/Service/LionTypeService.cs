using Repositories.Entities;
using Repositories.UOW;
using Services.IService;

namespace Services.Service
{
	public class LionTypeService : ILionTypeService
	{
		private readonly IUnitOfWork _unitOfWork;

		public LionTypeService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public List<LionType> GetLionType()
		{
			List<LionType> listLionType = new List<LionType>();
			listLionType = _unitOfWork.GetRepository<LionType>().Entities.ToList();
			return listLionType;
		}
	}
}
