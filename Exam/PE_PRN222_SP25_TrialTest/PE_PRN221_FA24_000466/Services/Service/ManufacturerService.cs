using Repositories.Entities;
using Repositories.UOW;
using Services.IService;

namespace Services.Service
{
	public class ManufacturerService : IManufacturerService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ManufacturerService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public List<Manufacturer> GetManufactureres()
		{
			List<Manufacturer> listManufactureres = new List<Manufacturer>();
			listManufactureres = _unitOfWork.GetRepository<Manufacturer>().Entities.ToList();
			return listManufactureres;
		}
	}
}
