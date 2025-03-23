using Repositories.Entities;
using Repositories.UOW;
using Services.IService;

namespace Services.Service
{
	public class AccountService : IAccountService
	{
		private readonly IUnitOfWork _unitOfWork;

		public AccountService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public Account GetAccountByEmail(string email)
		{
			Account? account = _unitOfWork.GetRepository<Account>()
				.Entities
				.FirstOrDefault(c => c.Email.Equals(email))
				?? throw new Exception("Account not found");

			return account;
		}
	}
}
