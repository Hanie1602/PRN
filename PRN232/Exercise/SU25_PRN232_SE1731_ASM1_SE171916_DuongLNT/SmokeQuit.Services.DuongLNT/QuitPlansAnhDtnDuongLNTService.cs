using SmokeQuit.Repositories.DuongLNT;
using SmokeQuit.Repositories.DuongLNT.Models;

namespace SmokeQuit.Services.DuongLNT
{
	public class QuitPlansAnhDtnDuongLNTService
	{
		private readonly QuitPlansAnhDtnDuongLNTRepository _repository;

		public QuitPlansAnhDtnDuongLNTService() => _repository ??= new QuitPlansAnhDtnDuongLNTRepository();

		public async Task<List<QuitPlansAnhDtn>> GetAllAsync()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<QuitPlansAnhDtn> GetByIdAsync(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task<int> CreateAsync(QuitPlansAnhDtn quitPlans)
		{
			return await _repository.CreateAsync(quitPlans);
		}

		public async Task<int> UpdateAsync(QuitPlansAnhDtn quitPlans)
		{
			return await _repository.UpdateAsync(quitPlans);
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var quitplans = await _repository.GetByIdAsync(id);
			return await _repository.RemoveAsync(quitplans);
		}
	}
}
