using SmokeQuit.Repositories.DuongLNT;
using SmokeQuit.Repositories.DuongLNT.Models;

namespace SmokeQuit.Services.DuongLNT
{
	//public interface ILeaderboardsDuongLntService
	//{

	//}

	public class LeaderboardsDuongLntService : ILeaderboardsDuongLntService
	{
		private readonly LeaderboardsDuongLNTRepository _repository;
		
		//Nếu null, không tham số thì new nó
		public LeaderboardsDuongLntService() => _repository ??= new LeaderboardsDuongLNTRepository();

		public LeaderboardsDuongLntService(LeaderboardsDuongLNTRepository repository) => _repository = repository;

		public async Task<int> CreateAsync(LeaderboardsDuongLnt leaderboards)
		{
			return await _repository.CreateAsync(leaderboards);
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var leaderboards = await _repository.GetByIdAsync(id);
			return await _repository.RemoveAsync(leaderboards);
		}

		public async Task<List<LeaderboardsDuongLnt>> GetAllAsync()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<LeaderboardsDuongLnt> GetByIdAsync(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task<List<LeaderboardsDuongLnt>> SearchAsync(string note, double money, string reason)
		{
			return await _repository.SearchAsync(note, money, reason);
		}

		public async Task<int> UpdateAsync(LeaderboardsDuongLnt leaderboards)
		{
			return await _repository.UpdateAsync(leaderboards);
		}

	}
}
