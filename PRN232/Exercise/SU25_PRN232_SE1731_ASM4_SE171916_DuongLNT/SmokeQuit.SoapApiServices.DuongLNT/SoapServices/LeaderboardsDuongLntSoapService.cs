using SmokeQuit.SoapApiServices.DuongLNT.SoapModels;
using System.ServiceModel;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace SmokeQuit.SoapApiServices.DuongLNT.SoapServices
{
	[ServiceContract]
	public interface ILeaderboardsDuongLntSoapService
	{
		[OperationContract]
		Task<List<LeaderboardsDuongLnt>> GetLeaderboardsDuongLntAsync();

		[OperationContract]
		Task<LeaderboardsDuongLnt> GetLeaderboardsDuongLntByIdAsync(int id);

		[OperationContract]
		Task<int> CreateAsync(LeaderboardsDuongLnt leaderboards);

		[OperationContract]
		Task<int> UpdateAsync(LeaderboardsDuongLnt leaderboards);

		[OperationContract]
		Task<int> DeleteAsync(int id);
	}


	public class LeaderboardsDuongLntSoapService : ILeaderboardsDuongLntSoapService
	{
		private readonly IServiceProviders _serviceProviders;

		public LeaderboardsDuongLntSoapService(IServiceProviders serviceProviders) => _serviceProviders = serviceProviders;

		public Task<int> CreateAsync(LeaderboardsDuongLnt leaderboards)
		{
			throw new NotImplementedException();
		}

		public Task<int> DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<LeaderboardsDuongLnt>> GetLeaderboardsDuongLntAsync()
		{
			try
			{
				var leaderboards = await _serviceProviders.LeaderboardsDuongLntService.GetAllAsync();

				var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

				var leaderboardsJsonString = JsonSerializer.Serialize(leaderboards, opt);
				var results = JsonSerializer.Deserialize<List<LeaderboardsDuongLnt>>(leaderboardsJsonString, opt);

				return results;
			}
			catch (Exception ex)
			{

			}
			return new List<LeaderboardsDuongLnt>();
		}

		public Task<LeaderboardsDuongLnt> GetLeaderboardsDuongLntByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<int> UpdateAsync(LeaderboardsDuongLnt leaderboards)
		{
			throw new NotImplementedException();
		}
	}
}
