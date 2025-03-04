using PRN222.Lab1.Repositories.Entities;
using PRN222.Lab1.Repositories;

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
			AccountMember? accountMember = _unitOfWork.GetRepository<AccountMember>()
				.Entities
				.FirstOrDefault(c => c.EmailAddress.Equals(email))
				?? throw new Exception("Account not found");

			return accountMember;
		}
	}
}
