using Lab1.Repositories.Entities;

namespace PRN222.Lab1.Services
{
	public interface IAccountService
    {
        AccountMember GetAccountByEmail(string email);
    }
}
