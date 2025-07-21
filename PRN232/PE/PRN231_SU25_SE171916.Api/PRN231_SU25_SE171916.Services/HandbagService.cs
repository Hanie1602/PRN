using PRN231_SU25_SE171916.Repositories.Models;
using PRN231_SU25_SE171916.Repositories.UOW;

namespace PRN231_SU25_SE171916.Services
{
	public class HandbagService : IHandbagService
	{
		private readonly IUnitOfWork _unitOfWork;
		public HandbagService() => _unitOfWork ??= new UnitOfWork();

		public async Task<List<Handbag>> GetAllAsync()
		{
			return await _unitOfWork.HandbagRepository.GetAllAsync();
		}

		public async Task<Handbag> GetByIdAsync(int id)
		{
			return await _unitOfWork.HandbagRepository.GetByIdAsync(id);
		}

		public async Task<List<Handbag>> SearchAsync(string modelName, string material)
		{
			return await _unitOfWork.HandbagRepository.SearchAsync(modelName, material);
		}

		public async Task<int> CreateAsync(Handbag bag)
		{
			//Id tự tăng
			if (bag.HandbagId == 0)
			{
				var all = await _unitOfWork.HandbagRepository.GetAllAsync();
				bag.HandbagId = all.Max(h => h.HandbagId) + 1;
			}

			return await _unitOfWork.HandbagRepository.CreateAsync(bag);
		}

		public async Task<int> UpdateAsync(Handbag bag)
		{
			return await _unitOfWork.HandbagRepository.UpdateAsync(bag);
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var bag = await _unitOfWork.HandbagRepository.GetByIdAsync(id);

			if (bag == null)
				return false;

			return await _unitOfWork.HandbagRepository.RemoveAsync(bag);
		}
	}
}
