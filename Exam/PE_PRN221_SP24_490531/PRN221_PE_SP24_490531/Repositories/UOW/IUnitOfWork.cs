using Repositories.GenericRepositories;

namespace Repositories.UOW
{
	public interface IUnitOfWork : IDisposable
	{
		void Save();

		IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
	}
}
