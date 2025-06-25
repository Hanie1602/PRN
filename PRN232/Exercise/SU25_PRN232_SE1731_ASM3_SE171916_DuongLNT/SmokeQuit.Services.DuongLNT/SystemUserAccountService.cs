using SmokeQuit.Repositories.DuongLNT.Models;

namespace SmokeQuit.Services.DuongLNT
{
	public class SystemUserAccountService
	{
		private readonly IUnitOfWork _unitOfWork;
		//private readonly SystemUserAccountRepository _repository;
		//public SystemUserAccountService() => _repository ??= new SystemUserAccountRepository();
		public SystemUserAccountService() => _unitOfWork ??= new UnitOfWork();


		public async Task<SystemUserAccount> GetUserAccount(string username, string password)
		{
			return await _unitOfWork.SystemUserAccountRepository.GetUserAccount(username, password);
		}

		public async Task<List<SystemUserAccount>> GetAllUserAsync()
		{
			return await _unitOfWork.SystemUserAccountRepository.GetAllAsync();
		}
	}
}
