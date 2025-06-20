using SmokeQuit.Repositories.DuongLNT.ModelExtensions;
using SmokeQuit.Repositories.DuongLNT.Models;

namespace SmokeQuit.GraphQLAPIServices.DuongLnt.GraphQLs
{
	public class LeaderboardsQueries
	{
		private readonly IServiceProviders _serviceProvider;

		public LeaderboardsQueries(IServiceProviders serviceProvider) => _serviceProvider = serviceProvider;

		public async Task<List<LeaderboardsDuongLnt>> GetLeaderboardsDuongLnt()
		{
			try
			{
				var result = await _serviceProvider.LeaderboardsDuongLntService.GetAllAsync();
				return result ?? new List<LeaderboardsDuongLnt>();
			}
			catch (Exception ex)
			{
				return new List<LeaderboardsDuongLnt>();
			}
		}

		public async Task<LeaderboardsDuongLnt> GetLeaderboardsDuongLntById(int id)
		{
			try
			{
				var result = await _serviceProvider.LeaderboardsDuongLntService.GetByIdAsync(id);
				return result ?? new LeaderboardsDuongLnt();
			}
			catch (Exception ex)
			{
				return new LeaderboardsDuongLnt();
			}
		}

		public async Task<PaginationResult<List<LeaderboardsDuongLnt>>> SearchLeaderboardsDuongLnt(SearchLeaderboardsRequest request)
		{
			try
			{
				var result = await _serviceProvider.LeaderboardsDuongLntService.SearchNew(request);
				return result ?? new PaginationResult<List<LeaderboardsDuongLnt>>();
			}
			catch (Exception ex)
			{
			}

			return new PaginationResult<List<LeaderboardsDuongLnt>>();
		}

	}
}
