using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SmokeQuit.Repositories.DuongLNT.ModelExtensions;
using SmokeQuit.Repositories.DuongLNT.Models;
using SmokeQuit.Services.DuongLNT;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmokeQuit.APIServices.BE.DuongLNT.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class LeaderboardsDuongLntController : ControllerBase
	{
		private readonly ILeaderboardsDuongLntService _leaderboardsDuongLntService;

		//Dùng cái này phải cấp phát vùng nhớ cho nó => đk trên program
		public LeaderboardsDuongLntController(ILeaderboardsDuongLntService leaderboardsDuongLntService) => _leaderboardsDuongLntService = leaderboardsDuongLntService;

		//public LeaderboardsDuongLntController(ILeaderboardsDuongLntService leaderboardsDuongLntService)
		//{
		//	_leaderboardsDuongLntService = leaderboardsDuongLntService;
		//}

		// GET: api/<LeaderboardsDuongLntController>
		[Authorize(Roles = "1,2")]
		[HttpGet]
		public async Task<IEnumerable<LeaderboardsDuongLnt>> Get()
		{
			return await _leaderboardsDuongLntService.GetAllAsync();
		}

		// GET api/<LeaderboardsDuongLntController>/5
		[Authorize(Roles = "1,2")]
		[HttpGet("{id}")]
		public async Task<LeaderboardsDuongLnt> Get(int id)
		{
			return await _leaderboardsDuongLntService.GetByIdAsync(id);
		}

		// POST api/<LeaderboardsDuongLntController>
		[Authorize(Roles = "1,2")]
		[HttpPost]
		public async Task<int> Post(LeaderboardsDuongLnt leaderboards)
		{
			if (ModelState.IsValid)
			{
				return await _leaderboardsDuongLntService.CreateAsync(leaderboards);
			}

			return 0;

			#region Test Post
			//		{
			//  "userId": 1,
			//  "planId": 4,
			//  "daySmokeFree": 7,
			//  "moneySave": 150000,
			//  "rankPosition": 12,
			//  "totalAchievements": 3,
			//  "progressScore": 0.6,
			//  "note": "Keep going strong!",
			//  "streakCount": 5,
			//  "communityContribution": 2,
			//  "isTopRanked": false,
			//  "lastUpdate": "2025-07-12T15:55:09.032Z",
			//  "createdTime": "2025-07-12T15:55:09.032Z"
			//}
			#endregion
		}

		// PUT api/<LeaderboardsDuongLntController>/5
		//[HttpPut("{id}")]
		[Authorize(Roles = "1,2")]
		[HttpPut]
		public async Task<int> Put(LeaderboardsDuongLnt leaderboards)
		{
			if (ModelState.IsValid)
			{
				return await _leaderboardsDuongLntService.UpdateAsync(leaderboards);
			}

			return 0;

			#region Test Put
			//			{
			//				"leaderboardsDuongLntid": 2009,
			//  "userId": 1,
			//  "planId": 4,
			//  "daySmokeFree": 31,
			//  "moneySave": 550000,
			//  "rankPosition": 1,
			//  "totalAchievements": 6,
			//  "progressScore": 0.85,
			//  "note": "Updated: You’re the top now!",
			//  "streakCount": 16,
			//  "communityContribution": 21,
			//  "isTopRanked": true,
			//  "lastUpdate": "2025-07-12T16:02:57.002Z",
			//  "createdTime": "2025-06-17T08:00:00",
			//  "plan": {
			//					"quitPlansAnhDtnid": 4,
			//    "userId": 3,
			//    "membershipPlanId": 3,
			//    "reason": "To live a healthier life",
			//    "startDate": "2025-05-23T00:00:00",
			//    "expectedQuitDate": "2025-06-22T00:00:00",
			//    "dailyCigaretteTarget": 5,
			//    "weeklyCheckinFrequency": 2,
			//    "motivationalMessage": "You can do it!",
			//    "healthGoals": "Run 5km",
			//    "budgetSavingGoal": 200000,
			//    "receiveMotivationReminder": true,
			//    "isCustomizedPlan": true,
			//    "createdAt": "2025-05-23T00:00:00",
			//    "updatedAt": "2025-05-23T00:00:00",
			//    "blogPostsAnVts": [],
			//    "leaderboardsDuongLnts": [],
			//    "membershipPlan": null,
			//    "user": null
			//  },
			//  "user": null
			//}
			#endregion
		}

		// DELETE api/<LeaderboardsDuongLntController>/5
		[Authorize(Roles = "1")]
		[HttpDelete("{id}")]
		public async Task<bool> Delete(int id)
		{
			return await _leaderboardsDuongLntService.DeleteAsync(id);
		}

		#region Comment tạm
		//[Authorize(Roles ="1,2")]
		//[HttpGet("{page}/{pageSize}")]
		//public async Task<IActionResult> Get(int page, int pageSize)
		//{
		//	var leaderboardsQueryable =  (await _leaderboardsDuongLntService.GetAllAsync()).AsQueryable();

		//	var totalCount = leaderboardsQueryable.Count();
		//	var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

		//	leaderboardsQueryable = leaderboardsQueryable.Skip((page - 1) * pageSize).Take(pageSize);

		//	var result = new
		//	{
		//		TotalItems = totalCount,
		//		TotalPages = totalPages,
		//		CurrentPage = page,
		//		PageSize = pageSize,
		//		LeaderBoards = leaderboardsQueryable.ToList()
		//	};

		//	return Ok(result);
		//}
		#endregion

		[HttpGet("{note}/{money}/{reason}/{currentPage}/{pageSize}")]
		[Authorize(Roles = "1,2")]
		public async Task<PaginationResult<List<LeaderboardsDuongLnt>>> Get(string note, double money, string reason, int currentPage, int pageSize)
		{
			return await _leaderboardsDuongLntService.SearchWithPagingAsync(note, money, reason, currentPage, pageSize);
		}

		[HttpGet("{note}/{money}/{reason}")]
		//[HttpGet("Search")]
		[Authorize(Roles = "1,2")]
		public async Task<List<LeaderboardsDuongLnt>> Get(string? note, double money, string? reason)
		{
			return await _leaderboardsDuongLntService.SearchAsync(note, money, reason);
		}

		[HttpGet("{currentPage}/{pageSize}")]
		[Authorize(Roles = "1,2")]
		public async Task<PaginationResult<List<LeaderboardsDuongLnt>>> Get(int currentPage, int pageSize)
		{
			return await _leaderboardsDuongLntService.GetAllWithPagingAsync(currentPage, pageSize);
		}

		[HttpPost("Search")]
		//[Authorize(Roles = "1,2")]
		public async Task<PaginationResult<List<LeaderboardsDuongLnt>>> Get(SearchLeaderboardsRequest request)
		{
			return await _leaderboardsDuongLntService.SearchWithPagingAsync(request.Note ?? "", request.Money ?? 0, request.Reason ?? "", request.CurrentPage, request.PageSize);
		}

		// GET: api/<LeaderboardsDuongLntController>
		[Authorize(Roles = "1,2")]
		[HttpGet("Search")]
		[EnableQuery]
		public async Task<IEnumerable<LeaderboardsDuongLnt>> Search()
		{
			return await _leaderboardsDuongLntService.GetAllAsync();
		}

	}
}
