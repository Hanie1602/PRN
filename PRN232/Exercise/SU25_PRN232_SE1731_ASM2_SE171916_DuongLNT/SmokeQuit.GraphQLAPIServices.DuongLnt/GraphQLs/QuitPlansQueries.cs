using SmokeQuit.Repositories.DuongLNT.Models;

namespace SmokeQuit.GraphQLAPIServices.DuongLnt.GraphQLs
{
	[ExtendObjectType(Name = "Query")]
	public class QuitPlansQueries
	{
		private readonly IServiceProviders _serviceProvider;

		public QuitPlansQueries(IServiceProviders serviceProvider) => _serviceProvider = serviceProvider;

		public async Task<List<QuitPlansAnhDtn>> GetQuitPlansAnhDtn()
		{
			try
			{
				var result = await _serviceProvider.QuitPlansAnhDtnDuongLNTService.GetAllAsync();
				return result ?? new List<QuitPlansAnhDtn>();
			}
			catch (Exception ex)
			{
				return new List<QuitPlansAnhDtn>();
			}

			//Test
			#region Test bên GraphQL
			//query QuitPlansAnhDtn{
			//  quitPlansAnhDtn {
			//    quitPlansAnhDtnid
			//    userId
			//    membershipPlanId
			//    reason
			//    startDate
			//    expectedQuitDate
			//    dailyCigaretteTarget
			//    weeklyCheckinFrequency
			//    motivationalMessage
			//    healthGoals
			//    budgetSavingGoal
			//    receiveMotivationReminder
			//    isCustomizedPlan
			//    createdAt
			//    updatedAt
			//    membershipPlan{
			//		membershipPlansAnhDtnid
			//    }
			//  }
			//}
			#endregion
		}
	}
}
