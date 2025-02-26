using PRN222.Lab1.Repositories;
using PRN222.Lab1.Repositories.Entities;

namespace PRN222.Lab1.Services
{
	public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo;

        public AccountService()
        {
            _repo = new AccountRepository();
        }

        public AccountMember GetAccountByEmail(string email)
        {
            return _repo.GetAccountByEmail(email);
        }
    }
}
