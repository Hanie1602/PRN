using Microsoft.EntityFrameworkCore;
using PRN231_SU25_SE171916.Repositories.Basic;
using PRN231_SU25_SE171916.Repositories.DBContext;
using PRN231_SU25_SE171916.Repositories.Models;

namespace PRN231_SU25_SE171916.Repositories
{
    public class SystemAccountRepository : GenericRepository<SystemAccount>
    {
        public SystemAccountRepository() { }
        public SystemAccountRepository(Summer2025HandbagDbContext context)
            => _context = context;
        public async Task<SystemAccount> GetUserAccount(string email, string password)
        {
            return await _context.SystemAccounts.FirstOrDefaultAsync(u => u.Email == email && u.Password == password && u.IsActive == true);
        }
    }
}
