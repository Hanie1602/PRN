using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmokeQuit.Repositories.DuongLNT.Models;

namespace SmokeQuit.MVCWebApp.FE.DuongLNT.Controllers
{
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
        
        //Mẫu ở dưới có thể xóa luôn
        //public async Task<IActionResult> Index()
        //{
        //    var sU25_PRN232_SE1731_G6_SmokeQuitContext = _context.LeaderboardsDuongLnts.Include(l => l.Plan).Include(l => l.User);
        //    return View(await sU25_PRN232_SE1731_G6_SmokeQuitContext.ToListAsync());
        //}



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

        //// GET: LeaderboardsDuongLnts/Create
        //public IActionResult Create()
        //{
        //    ViewData["PlanId"] = new SelectList(_context.QuitPlansAnhDtns, "QuitPlansAnhDtnid", "Reason");
        //    ViewData["UserId"] = new SelectList(_context.SystemUserAccounts, "UserAccountId", "Email");
        //    return View();
        //}

        //// POST: LeaderboardsDuongLnts/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("LeaderboardsDuongLntid,UserId,PlanId,DaySmokeFree,MoneySave,RankPosition,TotalAchievements,ProgressScore,Note,StreakCount,CommunityContribution,IsTopRanked,LastUpdate,CreatedTime")] LeaderboardsDuongLnt leaderboardsDuongLnt)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(leaderboardsDuongLnt);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["PlanId"] = new SelectList(_context.QuitPlansAnhDtns, "QuitPlansAnhDtnid", "Reason", leaderboardsDuongLnt.PlanId);
        //    ViewData["UserId"] = new SelectList(_context.SystemUserAccounts, "UserAccountId", "Email", leaderboardsDuongLnt.UserId);
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
