﻿using Microsoft.EntityFrameworkCore;
using PRN222.Lab2.Repositories.Entities;

namespace PRN222.Lab2.Repositories.Data
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		protected readonly MyStoreDbContext _dbContext;
		protected readonly DbSet<TEntity> _dbSet;

		public GenericRepository(MyStoreDbContext dbContext)
		{
			_dbContext = dbContext;
			_dbSet = dbContext.Set<TEntity>();
		}

		public IQueryable<TEntity> Entities => _dbSet;

		public void Delete(object id)
		{
			TEntity entity = _dbSet.Find(id)!;
			_dbSet.Remove(entity);
		}

		public void Insert(TEntity obj)
		{
			_dbSet.Add(obj);
		}

		public void Save()
		{
			_dbContext.SaveChanges();
		}

		public void Update(TEntity obj)
		{
			_dbSet.Entry(obj).State = EntityState.Modified;
		}


	}
}
