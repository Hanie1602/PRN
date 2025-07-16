using SmokeQuit.Repositories.DuongLNT.ModelExtensions;
using SmokeQuit.Repositories.DuongLNT.Models;

namespace SmokeQuit.Services.DuongLNT
{
	public class LeaderboardsDuongLntService : ILeaderboardsDuongLntService
	{
		private readonly IUnitOfWork _unitOfWork;

		//Nếu null, không tham số thì new nó
		public LeaderboardsDuongLntService() => _unitOfWork ??= new UnitOfWork();

		//public LeaderboardsDuongLntService(LeaderboardsDuongLNTRepository repository) => _repository = repository;

		public async Task<List<LeaderboardsDuongLnt>> GetAllAsync()
		{
			return await _unitOfWork.LeaderboardsDuongLNTRepository.GetAllAsync();
		}

		public async Task<LeaderboardsDuongLnt> GetByIdAsync(int id)
		{
			return await _unitOfWork.LeaderboardsDuongLNTRepository.GetById(id);
		}

		public async Task<int> CreateAsync(LeaderboardsDuongLnt leaderboards)
		{
			return await _unitOfWork.LeaderboardsDuongLNTRepository.CreateAsync(leaderboards);
		}

		public async Task<int> UpdateAsync(LeaderboardsDuongLnt leaderboards)
		{
			return await _unitOfWork.LeaderboardsDuongLNTRepository.UpdateAsync(leaderboards);
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var leaderboards = await _unitOfWork.LeaderboardsDuongLNTRepository.GetByIdAsync(id);
			return await _unitOfWork.LeaderboardsDuongLNTRepository.RemoveAsync(leaderboards);
		}

		public async Task<List<LeaderboardsDuongLnt>> SearchAsync(string note, double money, string reason)
		{
			return await _unitOfWork.LeaderboardsDuongLNTRepository.SearchAsync(note, money, reason);
		}

		public async Task<PaginationResult<List<LeaderboardsDuongLnt>>> SearchWithPagingAsync(string note, double money, string reason, int currentPage, int pageSize)
		{
			var paginationResult = await _unitOfWork.LeaderboardsDuongLNTRepository.SearchWithPagingAsync(note, money, reason, currentPage, pageSize);

			return paginationResult ?? new PaginationResult<List<LeaderboardsDuongLnt>>();
		}

		public async Task<PaginationResult<List<LeaderboardsDuongLnt>>> GetAllWithPagingAsync(int currentPage, int pageSize)
		{
			var paginationResult = await _unitOfWork.LeaderboardsDuongLNTRepository.GetAllWithPagingAsync(currentPage, pageSize);

			return paginationResult ?? new PaginationResult<List<LeaderboardsDuongLnt>>();
		}

		public async Task<PaginationResult<List<LeaderboardsDuongLnt>>> SearchNew(SearchLeaderboardsRequest search)
		{
			return await _unitOfWork.LeaderboardsDuongLNTRepository.SearchWithPagingAsync(search.Note, search.Money, search.Reason, search.CurrentPage, search.PageSize);
		}

	}
}
