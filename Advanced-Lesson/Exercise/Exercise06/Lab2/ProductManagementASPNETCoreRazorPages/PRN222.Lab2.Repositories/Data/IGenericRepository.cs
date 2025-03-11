namespace PRN222.Lab2.Repositories.Data
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		IQueryable<TEntity> Entities { get; }

		IEnumerable<TEntity> GetAll();

		Task<IList<TEntity>> GetAllAsync();

		void Insert(TEntity obj);

		void Update(TEntity obj);

		void Delete(object id);

		void Save();
	}
}
