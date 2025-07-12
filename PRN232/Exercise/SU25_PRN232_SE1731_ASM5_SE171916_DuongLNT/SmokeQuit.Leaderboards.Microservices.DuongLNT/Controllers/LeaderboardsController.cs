using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SmokeQuit.BussinessObject.Shared.Models.DuongLNT.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmokeQuit.Leaderboards.Microservices.DuongLNT.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LeaderboardsController : ControllerBase
	{
		private readonly ILogger _logger;
		private readonly IBus _bus;
		private List<LeaderboardsDuongLnt> Leaderboards;

		public LeaderboardsController(ILogger<LeaderboardsController> logger, IBus bus)
		{
			_logger = logger;
			_bus = bus;

			Leaderboards = new List<LeaderboardsDuongLnt>()
			{
				new LeaderboardsDuongLnt
				{
					LeaderboardsDuongLntid = 1,
					UserId = 101,
					PlanId = 1,
					DaySmokeFree = 30,
					MoneySave = 150.00,
					RankPosition = 1,
					TotalAchievements = 5,
					ProgressScore = 95.5,
					Note = "Great progress!",
					StreakCount = 10,
					CommunityContribution = 100,
					IsTopRanked = true,
					LastUpdate = DateTime.Now,
					CreatedTime = DateTime.Now
				},
				new LeaderboardsDuongLnt
				{
					LeaderboardsDuongLntid = 2,
					UserId = 102,
					PlanId = 2,
					DaySmokeFree = 20,
					MoneySave = 100.00,
					RankPosition = 2,
					TotalAchievements = 3,
					ProgressScore = 85.0,
					Note = "Keep it up!",
					StreakCount = 5,
					CommunityContribution = 50,
					IsTopRanked = false,
					LastUpdate = DateTime.Now.AddDays(-1),
					CreatedTime = DateTime.Now.AddDays(-1)
				}
			};

		}

		// GET: api/<LeaderboardsController>
		[HttpGet]
		public IEnumerable<LeaderboardsDuongLnt> Get()
		{
			return Leaderboards;
		}

		// GET api/<LeaderboardsController>/5
		[HttpGet("{id}")]
		public LeaderboardsDuongLnt Get(int id)
		{
			return Leaderboards.Find(Leaderboards => Leaderboards.LeaderboardsDuongLntid == id)
				?? throw new KeyNotFoundException($"Leaderboards with id {id} not found.");
		}

		// POST api/<LeaderboardsController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<LeaderboardsController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<LeaderboardsController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
