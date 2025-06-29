using Repositories.Entities;

namespace Services.IService
{
	public interface ILionAccountService
	{
		LionAccount GetAccountByEmail(string email);
	}
}
