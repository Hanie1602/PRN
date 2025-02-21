using Lab1.Repositories.Entities;

namespace PRN222.Lab1.Repositories
{
	public interface IAccountRepository
    {
        AccountMember GetAccountByEmail(string email);
    }
}
