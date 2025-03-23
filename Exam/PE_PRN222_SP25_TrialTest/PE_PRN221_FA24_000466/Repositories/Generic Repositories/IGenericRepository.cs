namespace Repositories.Generic_Repositories
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		IQueryable<TEntity> Entities { get; }

		void Insert(TEntity obj);

		void Update(TEntity obj);

		void Delete(object id);

		void Save();
	}
}
