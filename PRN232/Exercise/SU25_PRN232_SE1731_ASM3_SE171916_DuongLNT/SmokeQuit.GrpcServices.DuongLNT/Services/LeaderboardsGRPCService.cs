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
			catch(Exception ex) { }

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

		public override async Task<MutationResult> CreateAsync(LeaderboardsDuongLnt request, ServerCallContext context)
		{
			try
			{
				var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

				var protoJsonStrong = JsonSerializer.Serialize(request, opt);

				var item = JsonSerializer.Deserialize<SmokeQuit.Repositories.DuongLNT
					.Models.LeaderboardsDuongLnt>(protoJsonStrong, opt);

				item.LeaderboardsDuongLntid = null;

				var result = await _serviceProviders.LeaderboardsDuongLntService.CreateAsync(item);

				return new MutationResult() { Result = result };
			}
			catch(Exception ex) { }

			return new MutationResult() { Result = 0 };
		}
	}
}
