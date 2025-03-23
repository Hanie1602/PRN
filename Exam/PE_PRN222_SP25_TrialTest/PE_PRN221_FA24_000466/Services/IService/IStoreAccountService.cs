using Repositories.Entities;

namespace Services.IService
{
	public interface IStoreAccountService
	{
		StoreAccount GetAccountByEmail(string email);
	}
}
