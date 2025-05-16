using Microsoft.EntityFrameworkCore;
using SmokeQuit.Repositories.DuongLNT.Basic;
using SmokeQuit.Repositories.DuongLNT.DBContext;
using SmokeQuit.Repositories.DuongLNT.Models;

namespace SmokeQuit.Repositories.DuongLNT
{
	public class LeaderboardsDuongLNTRepository : GenericRepository<LeaderboardsDuongLnt>
	{
		public LeaderboardsDuongLNTRepository() => _context ??= new DBContext.SU25_PRN232_SE1731_G6_SmokeQuitContext();

		public LeaderboardsDuongLNTRepository(SU25_PRN232_SE1731_G6_SmokeQuitContext context) => _context = context;

		public async Task<List<LeaderboardsDuongLnt>> GetAllAsync()
		{
			var termDepositSlips = await _context.LeaderboardsDuongLnts.Include(l => l.Plan).ToListAsync();

			return termDepositSlips;
		}

		public async Task<LeaderboardsDuongLnt> GetById(int id)
		{
			var termDepositSlip = await _context.LeaderboardsDuongLnts.Include(d => d.Plan).FirstOrDefaultAsync(d => d.PlanId == id);

			return termDepositSlip ?? new LeaderboardsDuongLnt();
		}

		//Search 3 điều kiện

	}


	
}
