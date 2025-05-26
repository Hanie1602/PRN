using SmokeQuit.Repositories.DuongLNT.Models;

namespace SmokeQuit.Services.DuongLNT
{
	public interface ILeaderboardsDuongLntService
	{
		Task<List<LeaderboardsDuongLnt>> GetAllAsync();

		Task<LeaderboardsDuongLnt> GetByIdAsync(int id);

		Task<List<LeaderboardsDuongLnt>> SearchAsync(string note, double money, string reason);

		Task<int> CreateAsync(LeaderboardsDuongLnt leaderboards);
		Task<int> UpdateAsync(LeaderboardsDuongLnt leaderboards);
		Task<bool> DeleteAsync(int id);

	}
}
