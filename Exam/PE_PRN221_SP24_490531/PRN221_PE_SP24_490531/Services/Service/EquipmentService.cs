using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.UOW;
using Services.IService;

namespace Services.Service
{
	public class EquipmentService : IEquipmentService
	{
		private readonly IUnitOfWork _unitOfWork;

		public EquipmentService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public List<Equipment> GetEquipment(string? eqName, int? quantity, bool? sortByName, int? pageIndex = null, int? pageSize = null)
		{
			IQueryable<Equipment> query = _unitOfWork.GetRepository<Equipment>()
				.Entities
				.Include(e => e.Rooms)
				.OrderByDescending(e => e.CreatedAt);

			//Tìm kiếm AND
			if (!string.IsNullOrEmpty(eqName) && quantity.HasValue)
			{
				query = query.Where(e => e.EqName.ToLower().Contains(eqName.ToLower()) 
								&& e.Quantity == quantity.Value);
			}

			//Sắp xếp theo tên
			if (sortByName.HasValue)
			{
				query = sortByName.Value
					? query.OrderBy(e => e.EqName)
					: query.OrderByDescending(e => e.EqName);
			}

			//Phân trang
			if (pageIndex.HasValue && pageSize.HasValue)
			{
				int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
				int validPageSize = pageSize.Value > 0 ? pageSize.Value : 5;

				query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
			}

			return query.ToList();
		}

		public Equipment GetEquipmentById(int id)
		{
			Equipment? equipment = _unitOfWork.GetRepository<Equipment>()
				.Entities
				.Include(e => e.Rooms)
				.FirstOrDefault(e => e.EqID == id)
				?? throw new Exception("No equipment found");

			return equipment;
		}

		public int GetTotalEquipment(string? eqName, int? quantity)
		{
			IQueryable<Equipment> query = _unitOfWork.GetRepository<Equipment>()
				.Entities
				.Include(e => e.Rooms);

			//Tìm kiếm AND
			if (!string.IsNullOrEmpty(eqName) && quantity.HasValue)
			{
				query = query.Where(e => e.EqName.ToLower().Contains(eqName.ToLower())
								&& e.Quantity == quantity.Value);
			}

			return query.Count();
		}

		public void Save(Equipment e)
		{
			e.CreatedAt = DateTime.Now;
			e.UpdatedAt = DateTime.Now;

			_unitOfWork.GetRepository<Equipment>().Insert(e);
			_unitOfWork.Save();
		}

		public void Update(Equipment e)
		{
			e.UpdatedAt = DateTime.Now;

			_unitOfWork.GetRepository<Equipment>().Update(e);
			_unitOfWork.Save();
		}

		public void Delete(Equipment eq)
		{
			Equipment? equipment = _unitOfWork.GetRepository<Equipment>()
				.Entities
				.SingleOrDefault(e => e.EqID == eq.EqID)
				?? throw new Exception("No equipment found");

			_unitOfWork.GetRepository<Equipment>().Delete(equipment.EqID);
			_unitOfWork.Save();
		}

	}
}
