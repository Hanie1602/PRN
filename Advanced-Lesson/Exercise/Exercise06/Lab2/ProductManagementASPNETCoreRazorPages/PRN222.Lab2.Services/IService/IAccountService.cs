using PRN222.Lab2.Repositories.Entities;

namespace PRN222.Lab2.Services.IService
{
	public interface IAccountService
	{
		AccountMember GetAccountByEmail(string email);
	}
}
