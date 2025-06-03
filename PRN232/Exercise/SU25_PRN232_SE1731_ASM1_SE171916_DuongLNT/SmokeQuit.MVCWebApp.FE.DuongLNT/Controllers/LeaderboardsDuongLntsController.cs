using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SmokeQuit.Repositories.DuongLNT.Models;

namespace SmokeQuit.MVCWebApp.FE.DuongLNT.Controllers
{
	[Authorize]
	public class LeaderboardsDuongLntsController : Controller
    {
		//private readonly SU25_PRN232_SE1731_G6_SmokeQuitContext _context;

        private string APIEndPoint = "https://localhost:7124/api/";

        public LeaderboardsDuongLntsController()
        {

        }

		// GET: LeaderboardsDuongLnts
		public async Task<IActionResult> Index()
        {
			using (var httpClient = new HttpClient())
			{
				// Add Token to header of Request
				var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

				httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

				using (var response = await httpClient.GetAsync(APIEndPoint + "LeaderboardsDuongLnt"))
				{
					if (response.IsSuccessStatusCode)
					{
						var content = await response.Content.ReadAsStringAsync();
						var result = JsonConvert.DeserializeObject<List<LeaderboardsDuongLnt>>(content);

						if (result != null)
						{
							return View(result);
						}
					}
				}
			}

			return View(new List<LeaderboardsDuongLnt>());
		}

		#region Get Plans trong bảng phụ
		private async Task<List<QuitPlansAnhDtn>> GetPlans()
		{
			using (var httpClient = new HttpClient())
			{
				// Add Token to header of Request
				var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

				httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

				using (var response = await httpClient.GetAsync(APIEndPoint + "QuitPlansAnhDtn"))
				{
					if (response.IsSuccessStatusCode)
					{
						var content = await response.Content.ReadAsStringAsync();
						var result = JsonConvert.DeserializeObject<List<QuitPlansAnhDtn>>(content);

						if (result != null)
						{
							return result;
						}
					}
				}
			}

			return new List<QuitPlansAnhDtn>();
		}
		#endregion

		#region Get trong bảng User
		private async Task<List<SystemUserAccount>> GetUsers()
		{
			using (var httpClient = new HttpClient())
			{
				// Add Token to header of Request
				var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;

				httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

				using (var response = await httpClient.GetAsync(APIEndPoint + "SystemUserAccounts"))
				{
					if (response.IsSuccessStatusCode)
					{
						var content = await response.Content.ReadAsStringAsync();
						var result = JsonConvert.DeserializeObject<List<SystemUserAccount>>(content);

						if (result != null)
						{
							return result;
						}
					}
				}
			}

			return new List<SystemUserAccount>();
		}
		#endregion

		// GET: LeaderboardsDuongLnts/Create
		public async Task<IActionResult> Create()
		{
			ViewData["PlanId"] = new SelectList(await this.GetPlans(), "QuitPlansAnhDtnid", "Reason");

			ViewData["UserId"] = new SelectList(await this.GetUsers(), "UserAccountId", "UserName");
			return View();
		}

		// POST: LeaderboardsDuongLnts/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(LeaderboardsDuongLnt leaderboardsDuongLnt)
		{
			leaderboardsDuongLnt.UserId = 1;
			if (ModelState.IsValid)
			{
				using (var httpClient = new HttpClient())
				{
					var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
					httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);

					using (var response = await httpClient.PostAsJsonAsync(APIEndPoint + "LeaderboardsDuongLnt", leaderboardsDuongLnt))
					{
						if (response.IsSuccessStatusCode)
						{
							var content = await response.Content.ReadAsStringAsync();
							var result = JsonConvert.DeserializeObject<int>(content);

							if (result > 0)
							{
								return RedirectToAction(nameof(Index));
							}
						}
					}
				}
			}

			ViewData["PlanId"] = new SelectList(await GetPlans(), "QuitPlansAnhDtnid", "Reason", leaderboardsDuongLnt.PlanId);
			ViewData["UserId"] = new SelectList(await GetUsers(), "UserAccountId", "UserName", leaderboardsDuongLnt.UserId);

			return View(leaderboardsDuongLnt);
		}

		//// GET: LeaderboardsDuongLnts/Details/5
		//public async Task<IActionResult> Details(int? id)
		//{
		//    if (id == null)
		//    {
		//        return NotFound();
		//    }

		//    var leaderboardsDuongLnt = await _context.LeaderboardsDuongLnts
		//        .Include(l => l.Plan)
		//        .Include(l => l.User)
		//        .FirstOrDefaultAsync(m => m.LeaderboardsDuongLntid == id);
		//    if (leaderboardsDuongLnt == null)
		//    {
		//        return NotFound();
		//    }

		//    return View(leaderboardsDuongLnt);
		//}



		//// GET: LeaderboardsDuongLnts/Edit/5
		//public async Task<IActionResult> Edit(int? id)
		//{
		//    if (id == null)
		//    {
		//        return NotFound();
		//    }

		//    var leaderboardsDuongLnt = await _context.LeaderboardsDuongLnts.FindAsync(id);
		//    if (leaderboardsDuongLnt == null)
		//    {
		//        return NotFound();
		//    }
		//    ViewData["PlanId"] = new SelectList(_context.QuitPlansAnhDtns, "QuitPlansAnhDtnid", "Reason", leaderboardsDuongLnt.PlanId);
		//    ViewData["UserId"] = new SelectList(_context.SystemUserAccounts, "UserAccountId", "Email", leaderboardsDuongLnt.UserId);
		//    return View(leaderboardsDuongLnt);
		//}

		//// POST: LeaderboardsDuongLnts/Edit/5
		//// To protect from overposting attacks, enable the specific properties you want to bind to.
		//// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Edit(int id, [Bind("LeaderboardsDuongLntid,UserId,PlanId,DaySmokeFree,MoneySave,RankPosition,TotalAchievements,ProgressScore,Note,StreakCount,CommunityContribution,IsTopRanked,LastUpdate,CreatedTime")] LeaderboardsDuongLnt leaderboardsDuongLnt)
		//{
		//    if (id != leaderboardsDuongLnt.LeaderboardsDuongLntid)
		//    {
		//        return NotFound();
		//    }

		//    if (ModelState.IsValid)
		//    {
		//        try
		//        {
		//            _context.Update(leaderboardsDuongLnt);
		//            await _context.SaveChangesAsync();
		//        }
		//        catch (DbUpdateConcurrencyException)
		//        {
		//            if (!LeaderboardsDuongLntExists(leaderboardsDuongLnt.LeaderboardsDuongLntid))
		//            {
		//                return NotFound();
		//            }
		//            else
		//            {
		//                throw;
		//            }
		//        }
		//        return RedirectToAction(nameof(Index));
		//    }
		//    ViewData["PlanId"] = new SelectList(_context.QuitPlansAnhDtns, "QuitPlansAnhDtnid", "Reason", leaderboardsDuongLnt.PlanId);
		//    ViewData["UserId"] = new SelectList(_context.SystemUserAccounts, "UserAccountId", "Email", leaderboardsDuongLnt.UserId);
		//    return View(leaderboardsDuongLnt);
		//}

		//// GET: LeaderboardsDuongLnts/Delete/5
		//public async Task<IActionResult> Delete(int? id)
		//{
		//    if (id == null)
		//    {
		//        return NotFound();
		//    }

		//    var leaderboardsDuongLnt = await _context.LeaderboardsDuongLnts
		//        .Include(l => l.Plan)
		//        .Include(l => l.User)
		//        .FirstOrDefaultAsync(m => m.LeaderboardsDuongLntid == id);
		//    if (leaderboardsDuongLnt == null)
		//    {
		//        return NotFound();
		//    }

		//    return View(leaderboardsDuongLnt);
		//}

		//// POST: LeaderboardsDuongLnts/Delete/5
		//[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> DeleteConfirmed(int id)
		//{
		//    var leaderboardsDuongLnt = await _context.LeaderboardsDuongLnts.FindAsync(id);
		//    if (leaderboardsDuongLnt != null)
		//    {
		//        _context.LeaderboardsDuongLnts.Remove(leaderboardsDuongLnt);
		//    }

		//    await _context.SaveChangesAsync();
		//    return RedirectToAction(nameof(Index));
		//}

		//private bool LeaderboardsDuongLntExists(int id)
		//{
		//    return _context.LeaderboardsDuongLnts.Any(e => e.LeaderboardsDuongLntid == id);
		//}
	}
}
