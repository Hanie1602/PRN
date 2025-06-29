using Repositories.Entities;
using Repositories.UOW;
using Services.IService;

namespace Services.Service
{
	public class LionAccountService : ILionAccountService
	{
		private readonly IUnitOfWork _unitOfWork;

		public LionAccountService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public LionAccount GetAccountByEmail(string email)
		{
			LionAccount? account = _unitOfWork.GetRepository<LionAccount>()
				.Entities
				.FirstOrDefault(c => c.Email.Equals(email))
				?? throw new Exception("Account not found");

			return account;
		}
	}
}
