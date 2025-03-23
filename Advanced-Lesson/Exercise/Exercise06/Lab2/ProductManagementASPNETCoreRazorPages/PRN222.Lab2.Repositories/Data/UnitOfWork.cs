using PRN222.Lab2.Repositories.Entities;

namespace PRN222.Lab2.Repositories.Data
{
	public class UnitOfWork : IUnitOfWork
	{
		private bool disposed = false;
		private readonly MyStoreDbContext _dbContext;
		private IGenericRepository<Product>? _productRepository;
		private IGenericRepository<Category>? _categoryRepository;
		private IGenericRepository<AccountMember>? _accountMemberRepository;

		public UnitOfWork(MyStoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					Console.WriteLine("DbContext is being disposed.");
					_dbContext.Dispose();
				}
			}
			disposed = true;
		}

		public IGenericRepository<Product> ProductRepository
			=> _productRepository ??= new GenericRepository<Product>(_dbContext);

		public IGenericRepository<Category> CategoryRepository
			=> _categoryRepository ??= new GenericRepository<Category>(_dbContext);

		public IGenericRepository<AccountMember> AccountMemberRepository
			=> _accountMemberRepository ??= new GenericRepository<AccountMember>(_dbContext);

		public void Save()
		{
			_dbContext.SaveChanges();
		}
	}
}
