namespace PRN222.Lab1.Repositories.Data
{
	public interface IUnitOfWork : IDisposable
	{
		void Save();

		IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
	}
}
