using PRN222.Lab1.Repositories.Entities;

namespace PRN222.Lab1.Services.IService
{
	public interface IAccountService
	{
		AccountMember GetAccountByEmail(string email);
	}
}
