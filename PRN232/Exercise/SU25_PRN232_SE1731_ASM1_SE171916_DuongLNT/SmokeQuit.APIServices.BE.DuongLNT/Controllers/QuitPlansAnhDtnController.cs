using Microsoft.AspNetCore.Mvc;
using SmokeQuit.Repositories.DuongLNT.Models;
using SmokeQuit.Services.DuongLNT;

namespace SmokeQuit.APIServices.BE.DuongLNT.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuitPlansAnhDtnController : ControllerBase
	{
		private readonly QuitPlansAnhDtnDuongLNTService _quitPlansAnhDtnService;
		public QuitPlansAnhDtnController(QuitPlansAnhDtnDuongLNTService quitPlansAnhDtnService)
		{
			_quitPlansAnhDtnService = quitPlansAnhDtnService;
		}

		// GET: api/<QuitPlansAnhDtnController>
		[HttpGet]
		public async Task<IEnumerable<QuitPlansAnhDtn>> Get()
		{
			return await _quitPlansAnhDtnService.GetAllAsync();
		}

		// GET api/<QuitPlansAnhDtnController>/5
		[HttpGet("{id}")]
		public async Task<QuitPlansAnhDtn> Get(int id)
		{
			return await _quitPlansAnhDtnService.GetByIdAsync(id);
		}

		// POST api/<QuitPlansAnhDtnController>
		[HttpPost]
		public async Task<int> Post(QuitPlansAnhDtn quitPlans)
		{
			if (ModelState.IsValid)
			{
				return await _quitPlansAnhDtnService.CreateAsync(quitPlans);
			}

			return 0;

			#region Test Post
			//{
			//	"userId": 3,
			//  "membershipPlanId": 3,
			//  "reason": "To live a healthier life",
			//  "startDate": "2025-05-23T00:00:00",
			//  "expectedQuitDate": "2025-06-22T00:00:00",
			//  "dailyCigaretteTarget": 5,
			//  "weeklyCheckinFrequency": 2,
			//  "motivationalMessage": "You can do it!",
			//  "healthGoals": "Run 5km",
			//  "budgetSavingGoal": 200000,
			//  "receiveMotivationReminder": true,
			//  "isCustomizedPlan": true,
			//  "createdAt": "2025-05-23T00:00:00",
			//  "updatedAt": "2025-05-23T00:00:00"
			//}
			#endregion
		}

		// PUT api/<QuitPlansAnhDtnController>/5
		[HttpPut]
		public async Task<int> Put(QuitPlansAnhDtn quitPlans)
		{
			if (ModelState.IsValid)
			{
				return await _quitPlansAnhDtnService.UpdateAsync(quitPlans);
			}

			return 0;

			#region Test Put
			//{
			//	"quitPlansAnhDtnid": 4,
			//  "userId": 3,
			//  "membershipPlanId": 3,
			//  "reason": "Updated reason - Stay healthy and happy",
			//  "startDate": "2025-05-23T00:00:00",
			//  "expectedQuitDate": "2025-06-30T00:00:00",
			//  "dailyCigaretteTarget": 3,
			//  "weeklyCheckinFrequency": 1,
			//  "motivationalMessage": "Every day is a new chance!",
			//  "healthGoals": "Run 10km",
			//  "budgetSavingGoal": 250000,
			//  "receiveMotivationReminder": true,
			//  "isCustomizedPlan": false,
			//  "createdAt": "2025-05-23T00:00:00",
			//  "updatedAt": "2025-07-13T00:00:00",
			//  "blogPostsAnVts": [],
			//  "leaderboardsDuongLnts": [],
			//  "membershipPlan": null,
			//  "user": null
			//}

			#endregion
		}

		// DELETE api/<QuitPlansAnhDtnController>/5
		[HttpDelete("{id}")]
		public async Task<bool> Delete(int id)
		{
			return await _quitPlansAnhDtnService.DeleteAsync(id);
		}
	}
}
