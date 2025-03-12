using PRN222.Lab2.Repositories.Data;
using PRN222.Lab2.Repositories.Entities;
using PRN222.Lab2.Services.IService;

namespace PRN222.Lab2.Services.Service
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
			AccountMember? accountMember = _unitOfWork.AccountMemberRepository
				.Entities
				.FirstOrDefault(c => c.EmailAddress.Equals(email))
				?? throw new Exception("Account not found");

			return accountMember;
		}

	}
}
