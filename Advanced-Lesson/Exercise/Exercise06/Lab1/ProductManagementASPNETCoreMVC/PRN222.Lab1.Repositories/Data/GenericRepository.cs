using Microsoft.EntityFrameworkCore;
using PRN222.Lab1.Repositories.Entities;

namespace PRN222.Lab1.Repositories.Data
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		protected readonly MyStoreDbContext _unitOfWork;
		protected readonly DbSet<TEntity> _dbSet;

		public GenericRepository(MyStoreDbContext dbContext)
		{
			_unitOfWork = dbContext;
			_dbSet = dbContext.Set<TEntity>();
		}

		public IQueryable<TEntity> Entities => _dbSet;

		public void Delete(object id)
		{
			TEntity entity = _dbSet.Find(id)!;
			_dbSet.Remove(entity);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return _dbSet.AsEnumerable();
		}

		public async Task<IList<TEntity>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public void Insert(TEntity obj)
		{
			_dbSet.Add(obj);
		}

		public void Save()
		{
			_unitOfWork.SaveChanges();
		}

		public void Update(TEntity obj)
		{
			_dbSet.Entry(obj).State = EntityState.Modified;
		}

	}
}
