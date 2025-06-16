using SmokeQuit.Repositories.DuongLNT;
using SmokeQuit.Repositories.DuongLNT.DBContext;

public interface IUnitOfWork : IDisposable
{
	SystemUserAccountRepository SystemUserAccountRepository { get; }
	LeaderboardsDuongLNTRepository LeaderboardsDuongLNTRepository { get; }
	QuitPlansAnhDtnDuongLNTRepository QuitPlansAnhDtnDuongLNTRepository { get; }

	int SaveChangesWithTransaction();
	Task<int> SaveChangesWithTransactionAsync();
}

public class UnitOfWork : IUnitOfWork
{
	private readonly SU25_PRN232_SE1731_G6_SmokeQuitContext _context;
	private SystemUserAccountRepository _systemUserAccountRepository;
	private LeaderboardsDuongLNTRepository _leaderboardsDuongLNTRepository;
	private QuitPlansAnhDtnDuongLNTRepository _quitPlansAnhDtnDuongLNTRepository;


	public UnitOfWork() => _context ??= new SU25_PRN232_SE1731_G6_SmokeQuitContext();

	public SystemUserAccountRepository SystemUserAccountRepository
	{
		get { return _systemUserAccountRepository ??= new SystemUserAccountRepository(_context); }
	}

	public LeaderboardsDuongLNTRepository LeaderboardsDuongLNTRepository
	{
		get { return _leaderboardsDuongLNTRepository ??= new LeaderboardsDuongLNTRepository(_context); }
	}

	public QuitPlansAnhDtnDuongLNTRepository QuitPlansAnhDtnDuongLNTRepository
	{
		get { return _quitPlansAnhDtnDuongLNTRepository ??= new QuitPlansAnhDtnDuongLNTRepository(_context); }
	}

	public int SaveChangesWithTransaction()
	{
		int result = -1;

		//System.Data.IsolationLevel.Snapshot
		using (var dbContextTransaction = _context.Database.BeginTransaction())
		{
			try
			{
				result = _context.SaveChanges();
				dbContextTransaction.Commit();
			}
			catch (Exception)
			{
				//Log Exception Handling message                      
				result = -1;
				dbContextTransaction.Rollback();
			}
		}

		return result;
	}

	public async Task<int> SaveChangesWithTransactionAsync()
	{
		int result = -1;

		//System.Data.IsolationLevel.Snapshot
		using (var dbContextTransaction = _context.Database.BeginTransaction())
		{
			try
			{
				result = await _context.SaveChangesAsync();
				dbContextTransaction.Commit();
			}
			catch (Exception)
			{
				//Log Exception Handling message                      
				result = -1;
				dbContextTransaction.Rollback();
			}
		}

		return result;
	}

	public void Dispose()
	{
		_context?.Dispose();
	}
}