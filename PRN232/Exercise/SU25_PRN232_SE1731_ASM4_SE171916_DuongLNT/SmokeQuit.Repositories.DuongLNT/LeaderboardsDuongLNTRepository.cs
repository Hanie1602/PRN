using Microsoft.EntityFrameworkCore;
using SmokeQuit.Repositories.DuongLNT.Basic;
using SmokeQuit.Repositories.DuongLNT.DBContext;
using SmokeQuit.Repositories.DuongLNT.ModelExtensions;
using SmokeQuit.Repositories.DuongLNT.Models;

//Repositories cho bảng tham chiếu
namespace SmokeQuit.Repositories.DuongLNT
{
	public class LeaderboardsDuongLNTRepository : GenericRepository<LeaderboardsDuongLnt>
	{
		public LeaderboardsDuongLNTRepository() => _context ??= new DBContext.SU25_PRN232_SE1731_G6_SmokeQuitContext();

		public LeaderboardsDuongLNTRepository(SU25_PRN232_SE1731_G6_SmokeQuitContext context) => _context = context;

		public async Task<List<LeaderboardsDuongLnt>> GetAllAsync()
		{
			var leaderboards = await _context.LeaderboardsDuongLnts
				.Include(l => l.Plan)
				.Include(l => l.User)
				.ToListAsync();

			return leaderboards;
		}

		public async Task<LeaderboardsDuongLnt> GetById(int id)
		{
			var leaderboards = await _context.LeaderboardsDuongLnts
				.Include(l => l.Plan)
				.Include(l => l.User)
				.FirstOrDefaultAsync(l => l.LeaderboardsDuongLntid == id);

			return leaderboards ?? new LeaderboardsDuongLnt();
		}

		//Search 3 điều kiện
		public async Task<List<LeaderboardsDuongLnt>> SearchAsync(string note, double? money, string reason)
		{
			var leaderboards = await _context.LeaderboardsDuongLnts
				.Include(l => l.Plan)
				.Where(l =>
					(l.Note.Contains(note) || string.IsNullOrEmpty(note))
					&& (l.MoneySave == money || money == null || money == 0)
					&& (l.Plan.Reason.Contains(reason)))
				.ToListAsync();

			//Nếu null thì bên phía Client sẽ không cho nó trống
			return leaderboards ?? new List<LeaderboardsDuongLnt>();
		}

		public async Task<PaginationResult<List<LeaderboardsDuongLnt>>> SearchWithPagingAsync(string note, double? money, string reason, int currentPage, int pageeSize)
		{
			var leaderboards = await this.SearchAsync(note, money, reason);

			//Paging
			var totalItems = leaderboards.Count();
			var totalPages = (int)Math.Ceiling((double)totalItems / pageeSize);

			leaderboards = leaderboards.Skip((currentPage - 1) * pageeSize).Take(pageeSize).ToList();

			var result = new PaginationResult<List<LeaderboardsDuongLnt>>
			{
				TotalItems = totalItems,
				TotalPages = totalPages,
				CurrentPage = currentPage,
				PageSize = pageeSize,
				Items = leaderboards
			};

			return result;
		}

		public async Task<PaginationResult<List<LeaderboardsDuongLnt>>> GetAllWithPagingAsync(int currentPage, int pageSize)
		{
			var leaderboards = await this.GetAllAsync();

			//Paging
			var totalItems = leaderboards.Count();
			var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

			leaderboards = leaderboards.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

			var result = new PaginationResult<List<LeaderboardsDuongLnt>>
			{
				TotalItems = totalItems,
				TotalPages = totalPages,
				CurrentPage = currentPage,
				PageSize = pageSize,
				Items = leaderboards
			};
			return result;
		}

	}

}
