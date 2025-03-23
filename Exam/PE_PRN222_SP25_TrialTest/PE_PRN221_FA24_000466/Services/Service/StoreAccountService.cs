using Repositories.Entities;
using Repositories.UOW;
using Services.IService;

namespace Services.Service
{
	public class StoreAccountService : IStoreAccountService
	{
		private readonly IUnitOfWork _unitOfWork;

		public StoreAccountService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public StoreAccount GetAccountByEmail(string email)
		{
			StoreAccount? account = _unitOfWork.GetRepository<StoreAccount>()
				.Entities
				.FirstOrDefault(c => c.EmailAddress.Equals(email))
				?? throw new Exception("Account not found");

			return account;
		}

	}
}
