using SmokeQuit.Repositories.DuongLNT.ModelExtensions;
using SmokeQuit.Repositories.DuongLNT.Models;

namespace SmokeQuit.GraphQLAPIServices.DuongLnt.GraphQLs
{
	[ExtendObjectType(Name = "Query")]
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

			//Test
			#region Test bên GetAll GraphQL
			//query LeaderboardsDuongLnt {
			//  leaderboardsDuongLnt {
			//    leaderboardsDuongLntid
			//    userId
			//    planId
			//    daySmokeFree
			//    moneySave
			//    rankPosition
			//    totalAchievements
			//    progressScore
			//    note
			//    streakCount
			//    communityContribution
			//    isTopRanked
			//    createdTime
			//    lastUpdate
			//    plan {
			//      quitPlansAnhDtnid
			//    }
			//    user {
			//      userAccountId
			//      userName
			//    }
			//  }
			//}
			#endregion
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

			#region Test bên GetById GraphQL
			//query LeaderboardById {
			//	leaderboardsDuongLntById(id: 1003) {
			//		leaderboardsDuongLntid
			//		userId
			//		planId
			//		daySmokeFree
			//		moneySave
			//		rankPosition
			//		totalAchievements
			//		progressScore
			//		note
			//		streakCount
			//		communityContribution
			//		isTopRanked
			//		createdTime
			//		lastUpdate
			//plan {
			//		quitPlansAnhDtnid
			//}
			//user {
			//		userAccountId
			//		}
			//	}
			//}

			#endregion
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

			//Test
			#region Test Phân trang và có lọc bên GraphQL
			//query SearchLeaderboardsDuongLnt($input: SearchLeaderboardsRequestInput!) {
			//  searchLeaderboardsDuongLnt(request: $input) {
			//    items {
			//      leaderboardsDuongLntid
			//      daySmokeFree
			//      moneySave
			//      rankPosition
			//      totalAchievements
			//      note
			//      isTopRanked
			//      createdTime
			//      plan {
			//        quitPlansAnhDtnid
			//      }
			//      user {
			//        userAccountId
			//      }
			//    }
			//    totalItems
			//    totalPages
			//    currentPage
			//    pageSize
			//  }
			//}


			//GraphQL Variables
			// input": {
			//   "note": "",
			//   "money": 0,
			//   "reason": "",
			//   "currentPage": 1,
			//   "pageSize": 10
			// }
			#endregion
		}

	}
}
