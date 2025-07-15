using GraphQL;
using GraphQL.Client.Abstractions;
using SmokeQuit.GraphQLClients.BlazorWAS.DuongLNT.Models;

namespace SmokeQuit.GraphQLClients.BlazorWAS.DuongLNT.GraphQLClients
{
	public class GraphQLConsumer
	{
		private readonly IGraphQLClient _graphQLClient;

		public GraphQLConsumer(IGraphQLClient graphQLClient) => _graphQLClient = graphQLClient;

		public partial class LeaderboardsGraphQLResponse
		{
			public List<LeaderboardsDuongLnt> leaderboardsDuongLnt { get; set; }

		}

		public class LeaderboardByIdResponse
		{
			public LeaderboardsDuongLnt leaderboardsDuongLntById { get; set; }
		}

		public partial class QuitPlansGraphQLResponse
		{
			public List<QuitPlansAnhDtn> quitPlansAnhDtn { get; set; }
		}

		public class UsersGraphQLResponse
		{
			public List<SystemUserAccount> systemUserAccount { get; set; }
		}

		public class CreateLeaderboardsResponse
		{
			public int createLeaderboardsDuongLnt { get; set; }
		}

		public class UpdateLeaderboardsResponse
		{
			public int updateLeaderboardsDuongLnt { get; set; }
		}

		public class DeleteLeaderboardsResponse
		{
			public bool deleteLeaderboardsDuongLnt { get; set; }
		}

		#region Get của bảng chính
		public async Task<List<LeaderboardsDuongLnt>> GetLeaderboardsDuongLnt()
		{
			try
			{

				var query = @"
				query LeaderboardsDuongLnt {
					leaderboardsDuongLnt {
						leaderboardsDuongLntid
						daySmokeFree
						moneySave
						rankPosition
						totalAchievements
						note
						isTopRanked
						createdTime
						plan {
							quitPlansAnhDtnid
						}
						user {
							userAccountId
						}
					}
				}";

				var response = await _graphQLClient.SendQueryAsync<LeaderboardsGraphQLResponse>(query);

				var result = response?.Data?.leaderboardsDuongLnt;

				return result;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Lỗi GraphQL: " + ex.Message);
			}

			return new List<LeaderboardsDuongLnt>();
		}
		#endregion

		#region Get của bảng phụ
		public async Task<List<QuitPlansAnhDtn>> GetQuitPlansAnhDtn()
		{
			try
			{

				var query = @"
				query QuitPlansAnhDtn {
					quitPlansAnhDtn {
						quitPlansAnhDtnid
						reason
						startDate
						expectedQuitDate
						dailyCigaretteTarget
						healthGoals
						isCustomizedPlan
						createdAt
						membershipPlan {
							membershipPlansAnhDtnid
						}
						user {
							userAccountId
						}
					}
				}";

				var response = await _graphQLClient.SendQueryAsync<QuitPlansGraphQLResponse>(query);

				var result = response?.Data?.quitPlansAnhDtn;

				return result;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Lỗi GraphQL: " + ex.Message);
			}

			return new List<QuitPlansAnhDtn>();
		}
		#endregion

		#region Get của bảng User
		public async Task<List<SystemUserAccount>> GetUsersDuongLnt()
		{
			var query = @"
				query SystemUserAccount {
					systemUserAccount {
						userAccountId
						userName
					}
				}";

			try
			{
				var response = await _graphQLClient.SendQueryAsync<UsersGraphQLResponse>(query);
				return response?.Data?.systemUserAccount ?? new();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"GraphQL error: {ex.Message}");
				return new();
			}
		}
		#endregion

		#region Get By Id của bảng chính
		public async Task<LeaderboardsDuongLnt?> GetLeaderboardsDuongLntById(int id)
		{
			var query = @"
				query LeaderboardById($id: Int!) {
					leaderboardsDuongLntById(id: $id) {
						leaderboardsDuongLntid
						userId
						planId
						daySmokeFree
						moneySave
						rankPosition
						totalAchievements
						progressScore
						note
						streakCount
						communityContribution
						isTopRanked
						createdTime
						lastUpdate
						plan {
							quitPlansAnhDtnid
						}
						user {
							userAccountId
						}
					}
				}";

			var request = new GraphQLRequest
			{
				Query = query,
				Variables = new { id }
			};

			try
			{
				var response = await _graphQLClient.SendQueryAsync<LeaderboardByIdResponse>(request);
				return response?.Data?.leaderboardsDuongLntById;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"GraphQL error: {ex.Message}");
				return null;
			}
		}
		#endregion

		#region Create
		public async Task<int> CreateLeaderboardsDuongLnt(LeaderboardsDuongLnt leaderboards)
		{
			try
			{
				var mutation = @"
					mutation($leaderboards: LeaderboardsDuongLntInput!) {
						createLeaderboardsDuongLnt(leaderboards: $leaderboards)
					}";

				var variables = new
				{
					leaderboards = new
					{
						userId = leaderboards.User?.UserAccountId,
						planId = leaderboards.Plan?.QuitPlansAnhDtnid,
						daySmokeFree = leaderboards.DaySmokeFree,
						moneySave = leaderboards.MoneySave,
						rankPosition = leaderboards.RankPosition,
						totalAchievements = leaderboards.TotalAchievements,
						progressScore = leaderboards.ProgressScore,
						note = leaderboards.Note,
						streakCount = leaderboards.StreakCount,
						communityContribution = leaderboards.CommunityContribution,
						isTopRanked = leaderboards.IsTopRanked,
						lastUpdate = leaderboards.LastUpdate,
						createdTime = leaderboards.CreatedTime
					}
				};

				var response = await _graphQLClient.SendMutationAsync<CreateLeaderboardsResponse>(mutation, variables);
				return response.Data?.createLeaderboardsDuongLnt ?? 0;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Mutation Error: {ex.Message}");
				return 0;
			}
		}
		#endregion

		#region Update
		public async Task<int> UpdateLeaderboardsDuongLnt(LeaderboardsDuongLnt leaderboards)
		{
			var mutation = @"
				mutation($leaderboards: LeaderboardsDuongLntInput!) {
					updateLeaderboardsDuongLnt(leaderboards: $leaderboards)
				}";

			var variables = new
			{
				leaderboards = new
				{
					leaderboardsDuongLntid = leaderboards.LeaderboardsDuongLntid,
					userId = leaderboards.User?.UserAccountId,
					planId = leaderboards.Plan?.QuitPlansAnhDtnid,
					daySmokeFree = leaderboards.DaySmokeFree,
					moneySave = leaderboards.MoneySave,
					rankPosition = leaderboards.RankPosition,
					totalAchievements = leaderboards.TotalAchievements,
					progressScore = leaderboards.ProgressScore,
					note = leaderboards.Note,
					streakCount = leaderboards.StreakCount,
					communityContribution = leaderboards.CommunityContribution,
					isTopRanked = leaderboards.IsTopRanked,
					lastUpdate = leaderboards.LastUpdate,
					createdTime = leaderboards.CreatedTime
				}
			};

			try
			{
				var response = await _graphQLClient.SendMutationAsync<UpdateLeaderboardsResponse>(mutation, variables);
				return response.Data?.updateLeaderboardsDuongLnt ?? 0;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Lỗi khi cập nhật: {ex.Message}");
				return 0;
			}
		}
		#endregion

		#region Delete
		public async Task<bool> DeleteLeaderboardsDuongLnt(int id)
		{
			var mutation = @"
				mutation($id: Int!) {
					deleteLeaderboardsDuongLnt(id: $id)
				}";

			var variables = new { id };

			try
			{
				var response = await _graphQLClient.SendMutationAsync<DeleteLeaderboardsResponse>(mutation, variables);
				return response?.Data?.deleteLeaderboardsDuongLnt ?? false;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Lỗi khi xóa: {ex.Message}");
				return false;
			}
		}
		#endregion
	}
}
