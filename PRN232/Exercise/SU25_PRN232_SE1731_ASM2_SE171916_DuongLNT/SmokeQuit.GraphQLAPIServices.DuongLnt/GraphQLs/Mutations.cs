using SmokeQuit.Repositories.DuongLNT.Models;

namespace SmokeQuit.GraphQLAPIServices.DuongLnt.GraphQLs
{
	public class Mutations
	{
		//Don't Use ServiceProvide
		private readonly IServiceProviders _serviceProvider;

		public Mutations(IServiceProviders serviceProvider) => _serviceProvider = serviceProvider;

		#region Create
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

		//Test mutation bên GraphQL
		//mutation {
		//  createLeaderboardsDuongLnt(
		//		leaderboards: {
		//			userId: 1,
		//			planId: 4,
		//			daySmokeFree: 30,
		//			moneySave: 500000,
		//			rankPosition: 2,
		//			totalAchievements: 5,
		//			progressScore: 0.75,
		//			note: "Reached milestone",
		//			streakCount: 15,
		//			communityContribution: 20,
		//			isTopRanked: true,
		//			lastUpdate: "2025-06-17T08:00:00Z",
		//			createdTime: "2025-06-17T08:00:00Z"
		//		}
		//  )
		//}

		#endregion

		#region Update
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

		///Test mutation bên GraphQL
		//mutation {
		//  updateLeaderboardsDuongLnt(
		//		leaderboards: {
		//			leaderboardsDuongLntid: 1002,
		//			userId: 1,
		//			planId: 4,
		//			daySmokeFree: 45,
		//			moneySave: 750000,
		//			rankPosition: 1,
		//			totalAchievements: 6,
		//			progressScore: 0.85,
		//			note: "Updated milestone",
		//			streakCount: 20,
		//			communityContribution: 30,
		//			isTopRanked: true,
		//			lastUpdate: "2025-06-24T08:00:00Z",
		//			createdTime: "2025-06-17T08:00:00Z"
		//		}
		//  )
		//}
		#endregion

		#region Delete
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

		///Test mutation bên GraphQL
		//mutation {
		//  deleteLeaderboardsDuongLnt(id: 11)
		//}

		#endregion

		#region Login
		public async Task<SystemUserAccount?> Login(string username, string password)
		{
			try
			{
				var user = await _serviceProvider.UserAccountService.GetUserAccount(username, password);

				if (user == null)
				{
					throw new GraphQLException("Wrong account or password");
				}

				return user;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Login error: {ex.Message}");
				throw new GraphQLException("Login failed");
			}
		}

		/// Test GraphQL mutation
		//mutation {
		//  login(username: "acc", password: "@a") {
		//    userAccountId
		//    userName
		//    fullName
		//    roleId
		//  }
		//}
		#endregion

	}
}
