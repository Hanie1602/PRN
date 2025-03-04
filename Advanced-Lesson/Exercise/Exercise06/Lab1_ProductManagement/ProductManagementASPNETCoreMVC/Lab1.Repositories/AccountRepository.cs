using PRN222.Lab1.Repositories.Entities;

namespace PRN222.Lab1.Repositories
{
	public class AccountRepository : IAccountRepository
    {
        public AccountMember GetAccountByEmail(string email)
        {
            using MyStoreDbContext db = new MyStoreDbContext();
            return db.AccountMembers.FirstOrDefault(c => c.EmailAddress.Equals(email));
        }
    }
}
