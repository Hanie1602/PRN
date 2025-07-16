using PRN231_SU25_SE171916.Repositories;
using PRN231_SU25_SE171916.Repositories.DBContext;

public interface IUnitOfWork : IDisposable
{
    SystemAccountRepository SystemAccountRepository { get; }
    HandbagRepository HandbagRepository { get; }

	int SaveChangesWithTransaction();
	Task<int> SaveChangesWithTransactionAsync();
}

public class UnitOfWork : IUnitOfWork
{
	private readonly Summer2025HandbagDbContext _context;
	private SystemAccountRepository _systemAccountRepository;
	private HandbagRepository _handbagRepository;


	public UnitOfWork() => _context ??= new Summer2025HandbagDbContext();

	public SystemAccountRepository SystemAccountRepository
    {
		get { return _systemAccountRepository ??= new SystemAccountRepository(_context); }
	}

	public HandbagRepository HandbagRepository
    {
		get { return _handbagRepository ??= new HandbagRepository(_context); }
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