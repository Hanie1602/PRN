using SmokeQuit.Repositories.DuongLNT.Models;

namespace SmokeQuit.Services.DuongLNT
{
	public class SystemUserAccountService
	{
		private readonly IUnitOfWork _unitOfWork;
		public SystemUserAccountService() => _unitOfWork ??= new UnitOfWork();


		public async Task<SystemUserAccount> GetUserAccount(string username, string password)
		{
			return await _unitOfWork.SystemUserAccountRepository.GetUserAccount(username, password);
		}

		public async Task<List<SystemUserAccount>> GetAllUserAsync()
		{
			return await _unitOfWork.SystemUserAccountRepository.GetAllAsync();
		}

		public async Task<bool> ExistsAsync(int userId)
		{
			var allUsers = await _unitOfWork.SystemUserAccountRepository.GetAllAsync();
			return allUsers.Any(u => u.UserAccountId == userId);
		}

	}
}
