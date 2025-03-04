using PRN222.Lab1.Repositories.Entities;

namespace PRN222.Lab1.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private bool disposed = false;
		private readonly MyStoreDbContext _dbContext;
		private readonly Dictionary<Type, object> _repositories;

		public UnitOfWork(MyStoreDbContext dbContext)
		{
			_dbContext = dbContext;
			_repositories = [];
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					Console.WriteLine("DbContext is being disposed.");
					_dbContext.Dispose();
				}
			}
			disposed = true;
		}

		public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
		{
			if (_repositories.ContainsKey(typeof(TEntity)))
			{
				return (IGenericRepository<TEntity>)_repositories[typeof(TEntity)];
			}

			GenericRepository<TEntity> repository = new(_dbContext);
			_repositories.Add(typeof(TEntity), repository);
			return repository;
		}

		public void Save()
		{
			_dbContext.SaveChanges();
		}

	}
}
