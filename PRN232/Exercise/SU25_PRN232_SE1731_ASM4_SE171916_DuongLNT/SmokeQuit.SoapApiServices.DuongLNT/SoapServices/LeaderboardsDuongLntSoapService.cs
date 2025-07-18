﻿using SmokeQuit.SoapApiServices.DuongLNT.SoapModels;
using System.ServiceModel;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace SmokeQuit.SoapApiServices.DuongLNT.SoapServices
{
	[ServiceContract(Namespace = "http://tempuri.org/")]
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

		public LeaderboardsDuongLntSoapService(IServiceProviders serviceProviders)
		{
			_serviceProviders = serviceProviders;
		}

		public async Task<List<LeaderboardsDuongLnt>> GetLeaderboardsDuongLntAsync()
		{
			try
			{
				var result = new List<LeaderboardsDuongLnt>();
				var leaderboards = await _serviceProviders.LeaderboardsDuongLntService.GetAllAsync();

				var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

				var leaderboardsJsonString = JsonSerializer.Serialize(leaderboards, opt);
				result = JsonSerializer.Deserialize<List<LeaderboardsDuongLnt>>(leaderboardsJsonString, opt);

				return result;
			}
			catch (Exception ex)
			{

			}
			return new List<LeaderboardsDuongLnt>();
		}

		public async Task<LeaderboardsDuongLnt> GetLeaderboardsDuongLntByIdAsync(int id)
		{
			try
			{
				var leaderboards = await _serviceProviders.LeaderboardsDuongLntService.GetByIdAsync(id);
				var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
				var leaderboardJsonString = JsonSerializer.Serialize(leaderboards, opt);
				var result = JsonSerializer.Deserialize<LeaderboardsDuongLnt>(leaderboardJsonString, opt);
				return result;
			}
			catch (Exception ex) { }
			return new LeaderboardsDuongLnt();
		}

		#region Create
		public async Task<int> CreateAsync(LeaderboardsDuongLnt leaderboards)
		{
			try
			{
				var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
				var leaderboardJsonString = JsonSerializer.Serialize(leaderboards, opt);
				var leaderboardsRMO = JsonSerializer.Deserialize<Repositories.DuongLNT.Models.LeaderboardsDuongLnt>(leaderboardJsonString, opt);

				if (!await _serviceProviders.UserAccountService.ExistsAsync(leaderboards.UserId))
				{
					throw new Exception($"UserId {leaderboards.UserId} does not exist in table SystemUserAccount.");
				}
				Console.WriteLine(JsonSerializer.Serialize(leaderboards));

				var result = await _serviceProviders.LeaderboardsDuongLntService.CreateAsync(leaderboardsRMO);
				return result;
			}
			catch (Exception ex)
			{
				Console.WriteLine("CreateAsync Error: " + ex.Message);
				if (ex.InnerException != null)
					Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
			}
			return 0;
		}
		#endregion
		
		public async Task<int> UpdateAsync(LeaderboardsDuongLnt leaderboards)
		{
			try
			{
				// XÓA navigation property
				leaderboards.Plan = null;
				leaderboards.User = null;

				var opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

				var leaderboardJsonString = JsonSerializer.Serialize(leaderboards, opt);
				var leaderboardRMO = JsonSerializer.Deserialize<Repositories.DuongLNT.Models.LeaderboardsDuongLnt>(leaderboardJsonString, opt);

				//Ensure the ID is not default
				if (leaderboardRMO.LeaderboardsDuongLntid <= 0)
					throw new Exception("Invalid LeaderboardsDuongLntid");

				var result = await _serviceProviders.LeaderboardsDuongLntService.UpdateAsync(leaderboardRMO);
				return result;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message); // hoặc logger
			}
			return 0;
		}

		public async Task<int> DeleteAsync(int id)
		{
			try
			{
				var result = await _serviceProviders.LeaderboardsDuongLntService.DeleteAsync(id);
				return result ? 1 : 0;
			}
			catch (Exception ex) { }
			return 0;
		}
	}
}
