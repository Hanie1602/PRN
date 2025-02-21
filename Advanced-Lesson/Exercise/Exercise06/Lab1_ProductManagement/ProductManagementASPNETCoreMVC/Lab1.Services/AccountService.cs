using Lab1.Repositories.Entities;
using PRN222.Lab1.Repositories;

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
