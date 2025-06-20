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

		public async Task<List<LeaderboardsDuongLnt>> GetLeaderboardsDuongLnt()
		{
			try
			{

				var query = @"query LeaderboardsDuongLnt {
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


	}
}
