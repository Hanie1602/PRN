namespace PRN222.Lab1.Repositories
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		IQueryable<TEntity> Entities { get; }

		IEnumerable<TEntity> GetAll();

		Task<IList<TEntity>> GetAllAsync();

		void Insert(TEntity obj);

		void Update(TEntity obj);

		void Delete(Object id);

		void Save();
	}
}
