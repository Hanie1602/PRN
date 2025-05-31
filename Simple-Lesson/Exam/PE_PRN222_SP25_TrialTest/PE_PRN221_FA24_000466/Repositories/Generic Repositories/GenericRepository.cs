using Microsoft.EntityFrameworkCore;
using Repositories.Entities;

namespace Repositories.Generic_Repositories
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		protected readonly Sp25PharmaceuticalDBContext _dbContext;
		protected readonly DbSet<TEntity> _dbSet;

		public GenericRepository(Sp25PharmaceuticalDBContext dbContext)
		{
			_dbContext = dbContext;
			_dbSet = dbContext.Set<TEntity>();
		}

		public IQueryable<TEntity> Entities => _dbSet;

		public void Insert(TEntity obj)
		{
			_dbSet.Add(obj);
		}

		public void Update(TEntity obj)
		{
			_dbSet.Entry(obj).State = EntityState.Modified;
		}

		public void Delete(object id)
		{
			TEntity entity = _dbSet.Find(id)!;
			_dbSet.Remove(entity);
		}

		public void Save()
		{
			_dbContext.SaveChanges();
		}
	}
}
