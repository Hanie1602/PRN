using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.UOW;
using Services.IService;

namespace Services.Service
{
	public class LionProfileService : ILionProfileService
	{
		private readonly IUnitOfWork _unitOfWork;

		public LionProfileService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public List<LionProfile> GetLionProfile(bool? sortByName, int? pageIndex = null, int? pageSize = null)
		{
			IQueryable<LionProfile> query = _unitOfWork.GetRepository<LionProfile>()
				.Entities
				.Include(l => l.LionType);

			//Sắp xếp theo tên
			if (sortByName.HasValue)
			{
				query = sortByName.Value
					? query.OrderBy(l => l.LionName)
					: query.OrderByDescending(l => l.LionName);
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

		public LionProfile GetLionProfileById(int id)
		{
			LionProfile? lionProfile = _unitOfWork.GetRepository<LionProfile>()
				.Entities
				.Include(l => l.LionType)
				.FirstOrDefault(l => l.LionProfileId == id)
				?? throw new Exception("No Lion Profile found");

			return lionProfile;
		}

		public int GetTotalLionProfile(string? lionName, string? lionTypeName)
		{
			IQueryable<LionProfile> query = _unitOfWork.GetRepository<LionProfile>()
				.Entities
				.Include(l => l.LionType);

			//Tìm kiếm OR
			if (!string.IsNullOrEmpty(lionName) ||
				!string.IsNullOrEmpty(lionTypeName))
			{
				query = query.Where(l =>
					(!string.IsNullOrEmpty(lionName) &&
					 l.LionName.ToLower().Contains(lionName.ToLower())) ||
					(!string.IsNullOrEmpty(lionTypeName) &&
					 l.LionType.LionTypeName.ToLower().Contains(lionTypeName.ToLower()))
				);
			}

			//Nhóm kết quả
			var groupedResult = query
				.GroupBy(l => new { l.LionName, l.LionType.LionTypeName })
				.SelectMany(g => g);

			return query.Count();
		}

		public void Save(LionProfile l)
		{
			_unitOfWork.GetRepository<LionProfile>().Insert(l);
			_unitOfWork.Save();
		}

		public void Update(LionProfile l)
		{
			_unitOfWork.GetRepository<LionProfile>().Update(l);
			_unitOfWork.Save();
		}

		public void Delete(LionProfile l)
		{
			LionProfile? lionProfile = _unitOfWork.GetRepository<LionProfile>()
				.Entities
				.SingleOrDefault(lp => lp.LionProfileId == l.LionProfileId)
				?? throw new Exception("No equipment found");

			_unitOfWork.GetRepository<LionProfile>().Delete(lionProfile.LionProfileId);
			_unitOfWork.Save();
		}
	}
}
