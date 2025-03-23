using Repositories.Entities;

namespace Services.IService
{
	public interface IAccountService
	{
		Account GetAccountByEmail(string email);
	}
}
