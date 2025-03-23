using Repositories.Entities;
using Repositories.UOW;
using Services.IService;

namespace Services.Service
{
	public class RoomService : IRoomService
	{
		private readonly IUnitOfWork _unitOfWork;

		public RoomService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public List<Room> GetRooms()
		{
			List<Room> listManufactureres = new List<Room>();
			listManufactureres = _unitOfWork.GetRepository<Room>().Entities.ToList();
			return listManufactureres;
		}
	}
}
