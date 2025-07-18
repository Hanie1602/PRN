using Microsoft.EntityFrameworkCore;
using SmokeQuit.Repositories.DuongLNT.Basic;
using SmokeQuit.Repositories.DuongLNT.DBContext;
using SmokeQuit.Repositories.DuongLNT.Models;

namespace SmokeQuit.Repositories.DuongLNT
{
	public class SystemUserAccountRepository : GenericRepository<SystemUserAccount>
	{
		public SystemUserAccountRepository(LeaderboardsDuongLNTRepository context) { }

		public SystemUserAccountRepository(SU25_PRN232_SE1731_G6_SmokeQuitContext context) => _context = context;

		public async Task<SystemUserAccount> GetUserAccount (string userName, string password)
		{
			return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
		}


	}
}
