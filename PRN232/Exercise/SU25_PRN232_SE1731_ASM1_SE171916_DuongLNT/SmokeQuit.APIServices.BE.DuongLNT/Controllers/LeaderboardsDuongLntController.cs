using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmokeQuit.Repositories.DuongLNT.Models;
using SmokeQuit.Services.DuongLNT;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
		[Authorize(Roles ="1,2")]
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
			return await _leaderboardsDuongLntService.CreateAsync(leaderboards);
		}

		// PUT api/<LeaderboardsDuongLntController>/5
		//[HttpPut("{id}")]
		[Authorize(Roles = "1,2")]
		[HttpPut]
		public async Task<int> Put(LeaderboardsDuongLnt leaderboards)
		{
			return await _leaderboardsDuongLntService.UpdateAsync(leaderboards);
		}

		// DELETE api/<LeaderboardsDuongLntController>/5
		[Authorize(Roles = "1")]
		[HttpDelete("{id}")]
		public async Task<bool> Delete(int id)
		{
			return await _leaderboardsDuongLntService.DeleteAsync(id);
		}

		[Authorize(Roles ="1,2")]
		[HttpGet("{page}/{pageSize}")]
		public async Task<IActionResult> Get(int page, int pageSize)
		{
			var leaderboardsQueryable =  (await _leaderboardsDuongLntService.GetAllAsync()).AsQueryable();

			var totalCount = leaderboardsQueryable.Count();
			var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

			leaderboardsQueryable = leaderboardsQueryable.Skip((page - 1) * pageSize).Take(pageSize);

			var result = new
			{
				TotalItems = totalCount,
				TotalPages = totalPages,
				CurrentPage = page,
				PageSize = pageSize,
				LeaderBoards = leaderboardsQueryable.ToList()
			};

			return Ok(result);
		}
	}
}
