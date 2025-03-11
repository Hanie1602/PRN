namespace PRN222.Lab2.Repositories.Data
{
	public interface IUnitOfWork : IDisposable
	{
		void Save();

		IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
	}
}
