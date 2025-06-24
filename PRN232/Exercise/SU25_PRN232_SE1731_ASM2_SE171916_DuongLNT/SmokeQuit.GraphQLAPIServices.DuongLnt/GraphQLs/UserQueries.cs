using SmokeQuit.Repositories.DuongLNT.Models;

namespace SmokeQuit.GraphQLAPIServices.DuongLnt.GraphQLs
{
	[ExtendObjectType(Name = "Query")]
	public class UserQueries
	{
		private readonly IServiceProviders _serviceProvider;

		public UserQueries(IServiceProviders serviceProvider) => _serviceProvider = serviceProvider;

		public async Task<List<SystemUserAccount>> GetSystemUserAccount()
		{
			try
			{
				var result = await _serviceProvider.UserAccountService.GetAllUserAsync();
				return result ?? new List<SystemUserAccount>();
			}
			catch (Exception ex)
			{
				return new List<SystemUserAccount>();
			}

			//Test
			#region Test bên GraphQL
			//query SystemUserAccount{
			//	systemUserAccount{
			//		userAccountId
			//		userName
			//		password
			//		fullName
			//		email
			//		phone
			//		employeeCode
			//		roleId
			//		requestCode
			//		createdDate
			//		applicationCode
			//		createdBy
			//		modifiedDate
			//		modifiedBy
			//		isActive
			//	}
			//}
			#endregion
		}
	}
}
