using PRN222.Lab2.Repositories.Entities;

namespace PRN222.Lab2.Repositories.Data
{
	public interface IUnitOfWork : IDisposable
	{
		void Save();

		IGenericRepository<Product> ProductRepository { get; }

		IGenericRepository<Category> CategoryRepository { get; }

		IGenericRepository<AccountMember> AccountMemberRepository { get; }
	}
}
