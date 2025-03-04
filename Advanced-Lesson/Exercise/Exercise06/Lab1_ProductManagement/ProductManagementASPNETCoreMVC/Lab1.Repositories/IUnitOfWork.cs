namespace PRN222.Lab1.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		void Save();
		Task SaveAsync();
		IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
	}
}
