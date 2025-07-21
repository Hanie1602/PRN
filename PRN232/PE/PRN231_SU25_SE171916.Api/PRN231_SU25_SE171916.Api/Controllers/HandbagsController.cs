using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using PRN231_SU25_SE171916.Repositories.Models;
using PRN231_SU25_SE171916.Services;

namespace PRN231_SU25_SE171916.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HandbagsController : BaseController
	{
		private readonly IHandbagService _handbagService;
		public HandbagsController(IHandbagService handbagService)
		{
			_handbagService = handbagService;
		}

		[Authorize(Roles = "1,2,3,4")]
		[HttpGet]
		public async Task<IEnumerable<Handbag>> Get()
		{
			//200, 401, 403
			return await _handbagService.GetAllAsync();
		}

		[Authorize(Roles = "1,2,3,4")]
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			//200, 401, 403, 404
			var handbag = await _handbagService.GetByIdAsync(id);
			if (handbag == null)
				return NotFound();

			return Ok(handbag);
		}

		[Authorize(Roles = "1,2")]
		[HttpPost]
		public async Task<IActionResult> Post(Handbag bag)
		{
			//201, 400, 401, 403
			if (!ModelState.IsValid)
			{
				var firstError = ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault()?.ErrorMessage ?? "Invalid input";
				return Error("HB40001", firstError, 400);
			}

			await _handbagService.CreateAsync(bag);

			return CreatedAtAction(nameof(Get), new { id = bag.HandbagId }, bag);

		}

		[Authorize(Roles = "1,2")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, Handbag bag)
		{
			//200, 400, 404, 401, 403
			if (!ModelState.IsValid)
			{
				var firstError = ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault()?.ErrorMessage ?? "Invalid input";
				return Error("HB40001", firstError, 400);
			}

			if (id != bag.HandbagId)
				return Error("HB40001", "ID mismatch between URL and body.", 400);

			//404
			var existing = await _handbagService.GetByIdAsync(id);
			if (existing == null)
				return Error("HB40401", $"Handbag with id {id} not found.", 404);

			await _handbagService.UpdateAsync(bag);
			return Ok();
		}

		[Authorize(Roles = "1,2")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			//200, 404, 401, 403
			var result = await _handbagService.DeleteAsync(id);
			if (!result)
				return NotFound(); // 404

			return Ok(); // 200
		}

		[HttpGet("Search")]
		[Authorize(Roles = "1,2,3,4")]
		[EnableQuery]
		public async Task<List<Handbag>> SearchAsync(string modelName, string material)
		{
			return await _handbagService.SearchAsync(modelName, material);
		}
	}
}
