namespace PRN222.Lab1.Repositories
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		IQueryable<TEntity> Entities { get; }

		IEnumerable<TEntity> GetAll();

		Task<IList<TEntity>> GetAllAsync();

		void Insert(TEntity obj);

		Task InsertAsync(TEntity obj);

		void Update(TEntity obj);

		Task UpdateAsync(TEntity obj);

		void Delete(Object id);

		Task DeleteAsync(Object id);

		void Save();

		Task SaveAsync();
	}
}
