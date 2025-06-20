using SmokeQuit.Repositories.DuongLNT.Models;

namespace SmokeQuit.GraphQLAPIServices.DuongLnt.GraphQLs
{
	public class Mutations
	{
		//Don't Use ServiceProvide
		private readonly IServiceProviders _serviceProvider;

		public Mutations(IServiceProviders serviceProvider) => _serviceProvider = serviceProvider;

		#region Mutation for Leaderboards
		public async Task<int> CreateLeaderboardsDuongLnt(LeaderboardsDuongLnt leaderboards)
		{
			try
			{
				var result = await _serviceProvider.LeaderboardsDuongLntService.CreateAsync(leaderboards);
				return (int)result;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");

				if (ex.InnerException != null)
				{
					Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
				}
			}

			return 0;
		}

		#region Test chạy
		//		mutation {
		//  createLeaderboardsDuongLnt(
		//	leaderboards: {
		//		userId: 1,
		//      planId: 4,
		//      daySmokeFree: 30,
		//      moneySave: 500000,
		//      rankPosition: 2,
		//      totalAchievements: 5,
		//      progressScore: 0.75,
		//      note: "Reached milestone",
		//      streakCount: 15,
		//      communityContribution: 20,
		//      isTopRanked: true,
		//      lastUpdate: "2025-06-17T08:00:00Z",
		//      createdTime: "2025-06-17T08:00:00Z"


		//	}
		//  )
		//}

		#endregion

		#endregion



		public async Task<int> UpdateLeaderboardsDuongLnt(LeaderboardsDuongLnt leaderboards)
		{
			try
			{
				var result = await _serviceProvider.LeaderboardsDuongLntService.UpdateAsync(leaderboards);
				return (int)result;
			}
			catch (Exception ex)
			{
			}

			return 0;
		}

		public async Task<bool> DeleteLeaderboardsDuongLnt(int id)
		{
			try
			{
				var result = await _serviceProvider.LeaderboardsDuongLntService.DeleteAsync(id);
				return result;
			}
			catch (Exception ex)
			{
			}
			return false;
		}


	}
}
