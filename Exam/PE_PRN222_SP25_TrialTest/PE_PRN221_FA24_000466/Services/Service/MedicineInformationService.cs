using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.UOW;
using Services.IService;

namespace Services.Service
{
	public class MedicineInformationService : IMedicineInformationService
	{
		private readonly IUnitOfWork _unitOfWork;

		public MedicineInformationService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public List<MedicineInformation> GetMedicineInformations(string? activeIngredients, string? expirationDate, string? warnings, bool? sortByName, int? pageIndex = null, int? pageSize = null)
		{
			IQueryable<MedicineInformation> query = _unitOfWork.GetRepository<MedicineInformation>()
				.Entities
				.Include(m => m.Manufacturer);

			//Tìm kiếm OR
			if (!string.IsNullOrEmpty(activeIngredients) ||
				!string.IsNullOrEmpty(expirationDate) ||
				!string.IsNullOrEmpty(warnings))
			{
				query = query.Where(m =>
					(!string.IsNullOrEmpty(activeIngredients) &&
					 m.ActiveIngredients.ToLower().Contains(activeIngredients.ToLower())) ||
					(!string.IsNullOrEmpty(expirationDate) &&
					 m.ExpirationDate != null &&
					 m.ExpirationDate.ToLower().Contains(expirationDate.ToLower())) ||
					(!string.IsNullOrEmpty(warnings) &&
					 m.WarningsAndPrecautions.ToLower().Contains(warnings.ToLower()))
				);
			}

			//Nhóm kết quả
			var groupedResult = query
				.GroupBy(m => new { m.ActiveIngredients, m.ExpirationDate, m.WarningsAndPrecautions })
				.SelectMany(g => g);

			//Sắp xếp theo tên
			if (sortByName.HasValue)
			{
				query = sortByName.Value
					? query.OrderBy(m => m.MedicineName)
					: query.OrderByDescending(m => m.MedicineName);
			}

			//Phân trang
			if (pageIndex.HasValue && pageSize.HasValue)
			{
				int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
				int validPageSize = pageSize.Value > 0 ? pageSize.Value : 3;

				query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
			}

			return query.ToList();
		}

		public MedicineInformation GetMedicineInformationById(string id)
		{
			MedicineInformation? medicine = _unitOfWork.GetRepository<MedicineInformation>()
				.Entities
				.Include(m => m.Manufacturer)
				.FirstOrDefault(med => med.MedicineID == id)
				?? throw new Exception("No medicine information found");

			return medicine;
		}

		public int GetTotalMedicineInformations(string? activeIngredients, string? expirationDate, string? warnings)
		{
			IQueryable<MedicineInformation> query = _unitOfWork.GetRepository<MedicineInformation>()
				.Entities
				.Include(m => m.Manufacturer);

			if (!string.IsNullOrEmpty(activeIngredients) 
				|| !string.IsNullOrEmpty(expirationDate) 
				|| !string.IsNullOrEmpty(warnings))
			{
				query = query.Where(m =>
					(!string.IsNullOrEmpty(activeIngredients) &&
					 m.ActiveIngredients.ToLower().Contains(activeIngredients.ToLower())) ||
					(!string.IsNullOrEmpty(expirationDate) &&
					 m.ExpirationDate != null &&
					 m.ExpirationDate.ToLower().Contains(expirationDate.ToLower())) ||
					(!string.IsNullOrEmpty(warnings) &&
					 m.WarningsAndPrecautions.ToLower().Contains(warnings.ToLower()))
				);
			}

			//Group theo yêu cầu rồi đếm
			return query
				.GroupBy(m => new { m.ActiveIngredients, m.ExpirationDate, m.WarningsAndPrecautions })
				.Count();
		}

		public void Save(MedicineInformation m)
		{
			_unitOfWork.GetRepository<MedicineInformation>().Insert(m);
			_unitOfWork.Save();
		}

		public void Update(MedicineInformation m)
		{
			_unitOfWork.GetRepository<MedicineInformation>().Update(m);
			_unitOfWork.Save();
		}

		public void Delete(MedicineInformation m)
		{
			MedicineInformation? medicine = _unitOfWork.GetRepository<MedicineInformation>()
				.Entities
				.SingleOrDefault(c => c.MedicineID == m.MedicineID)
				?? throw new Exception("No medicine information found");

			_unitOfWork.GetRepository<MedicineInformation>().Delete(medicine.MedicineID);
			_unitOfWork.Save();
		}
	}
}
