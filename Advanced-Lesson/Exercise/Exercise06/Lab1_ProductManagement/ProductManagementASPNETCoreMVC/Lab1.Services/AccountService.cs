using PRN222.Lab1.Repositories;
using PRN222.Lab1.Repositories.Entities;

namespace PRN222.Lab1.Services
{
	public class AccountService : IAccountService
    {
		private readonly IUnitOfWork _unitOfWork;

		public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AccountMember GetAccountByEmail(string email)
        {
            return _unitOfWork.GetRepository<AccountMember>().Entities.FirstOrDefault(c => c.EmailAddress.Equals(email));
		}
    }
}
