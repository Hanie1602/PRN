using Grpc.Core;
using SmokeQuit.GrpcServices.DuongLNT.Protos;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SmokeQuit.GrpcServices.DuongLNT.Services
{
	public class LeaderboardsGRPCService : LeaderboardsDuongLntGRPC.LeaderboardsDuongLntGRPCBase
	{
		private readonly IServiceProviders _serviceProviders;

		public LeaderboardsGRPCService(IServiceProviders serviceProviders) => _serviceProviders = serviceProviders;

		public override async Task<LeaderboardsDuongLntList> GetAllAsync(EmptyRequest request, ServerCallContext context)
		{
			var result = new LeaderboardsDuongLntList();

			try
			{
				var leaderboards = await _serviceProviders.LeaderboardsDuongLntService.GetAllAsync();

				var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

				var leaderboardsJsonString = JsonSerializer.Serialize(leaderboards, opt);
				var items = JsonSerializer.Deserialize<List<LeaderboardsDuongLnt>>(leaderboardsJsonString, opt);
				result.Items.AddRange(items);
			}
			catch (Exception ex) { }

			return result;
		}

		public override async Task<LeaderboardsDuongLnt> GetByIdAsync(LeaderboardsDuongLntIdRequest request, ServerCallContext context)
		{
			try
			{
				var leaderboards = await _serviceProviders.LeaderboardsDuongLntService.GetByIdAsync(request.LeaderboardsDuongLntid);

				var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

				var leaderboardsJsonString = JsonSerializer.Serialize(leaderboards, opt);
				var item = JsonSerializer.Deserialize<LeaderboardsDuongLnt>(leaderboardsJsonString, opt);
				return item;
			}
			catch (Exception ex) { }

			return new LeaderboardsDuongLnt();
		}

		public override async Task<MutationResult> CreateAsync(LeaderboardsDuongLntCreate request, ServerCallContext context)
		{
			try
			{
				var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

				var protoJsonStrong = JsonSerializer.Serialize(request, opt);

				var item = JsonSerializer.Deserialize<SmokeQuit.Repositories.DuongLNT
					.Models.LeaderboardsDuongLnt>(protoJsonStrong, opt);

				var result = await _serviceProviders.LeaderboardsDuongLntService.CreateAsync(item);

				return new MutationResult() { Result = result };
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in CreateAsync: {ex.Message}");
				if (ex.InnerException != null)
					Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
			}

			return new MutationResult() { Result = 0 };

			#region Test Create
			//	{
			//		"UserId": 1,
			//      "PlanId": 4,
			//      "DaySmokeFree": 10,
			//      "MoneySave": 0,
			//      "RankPosition": 11,
			//      "TotalAchievements": 0,
			//      "ProgressScore": 13,
			//      "Note": "You can do it!",
			//      "StreakCount": 0,
			//      "CommunityContribution": 0,
			//      "IsTopRanked": false,
			//      "LastUpdate": "2025-06-03T10:48:41.34",
			//      "CreatedTime": "2025-06-03T10:48:41.34"
			//}
			#endregion
		}

		public override async Task<MutationResult> UpdateAsync(LeaderboardsDuongLnt request, ServerCallContext context)
		{
			try
			{
				var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

				var protoJsonString = JsonSerializer.Serialize(request, opt);

				var item = JsonSerializer.Deserialize<SmokeQuit.Repositories.DuongLNT.Models.LeaderboardsDuongLnt>(protoJsonString, opt);

				var result = await _serviceProviders.LeaderboardsDuongLntService.UpdateAsync(item);

				return new MutationResult() { Result = result };
			}
			catch (Exception ex) { }

			return new MutationResult() { Result = 0 };

			#region Test Update
			//{
			//	"LeaderboardsDuongLntid": 1003,
			//  "UserId": 1,
			//  "PlanId": 4,
			//  "DaySmokeFree": 10,
			//  "MoneySave": 0,
			//  "RankPosition": 11,
			//  "TotalAchievements": 0,
			//  "ProgressScore": 13,
			//  "Note": "You can do it!",
			//  "StreakCount": 0,
			//  "CommunityContribution": 0,
			//  "IsTopRanked": false,
			//  "LastUpdate": "2025-06-03T10:48:00",
			//  "CreatedTime": "2025-06-03T10:48:41.34"
			//}
			#endregion
		}

		public override async Task<MutationResult> DeleteAsync(LeaderboardsDuongLntIdRequest request, ServerCallContext context)
		{
			try
			{
				var result = await _serviceProviders.LeaderboardsDuongLntService.DeleteAsync(request.LeaderboardsDuongLntid);

				return new MutationResult() { Result = result ? 1 : 0 };

			}
			catch (Exception ex) { }

			return new MutationResult() { Result = 0 };

			#region Test Delete
			//{
			//	"LeaderboardsDuongLntid": 1002
			//}
			#endregion
		}

	}
}
