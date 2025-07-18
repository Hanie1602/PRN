using SmokeQuit.Repositories.DuongLNT.ModelExtensions;
using SmokeQuit.Repositories.DuongLNT.Models;

namespace SmokeQuit.Services.DuongLNT
{
	public class LeaderboardsDuongLntService : ILeaderboardsDuongLntService
	{
		private readonly IUnitOfWork _unitOfWork;

		public LeaderboardsDuongLntService() => _unitOfWork ??= new UnitOfWork();

		#region Get All (Ko phân trang, ko search)
		public async Task<List<LeaderboardsDuongLnt>> GetAllAsync()
		{
			return await _unitOfWork.LeaderboardsDuongLNTRepository.GetAllAsync();
		}
		#endregion

		#region Get All có phân trang
		public async Task<PaginationResult<List<LeaderboardsDuongLnt>>> GetAllWithPagingAsync(int currentPage, int pageSize)
		{
			var paginationResult = await _unitOfWork.LeaderboardsDuongLNTRepository.GetAllWithPagingAsync(currentPage, pageSize);

			return paginationResult ?? new PaginationResult<List<LeaderboardsDuongLnt>>();
		}
		#endregion

		#region Get có search
		public async Task<List<LeaderboardsDuongLnt>> SearchAsync(string note, double money, string reason)
		{
			return await _unitOfWork.LeaderboardsDuongLNTRepository.SearchAsync(note, money, reason);
		}
		#endregion

		#region Get All có search và phân trang
		public async Task<PaginationResult<List<LeaderboardsDuongLnt>>> SearchNew(SearchLeaderboardsRequest search)
		{
			return await _unitOfWork.LeaderboardsDuongLNTRepository.SearchWithPagingAsync(search.Note, search.Money, search.Reason, search.CurrentPage, search.PageSize);
		}
		#endregion

		#region Get By Id
		public async Task<LeaderboardsDuongLnt> GetByIdAsync(int id)
		{
			return await _unitOfWork.LeaderboardsDuongLNTRepository.GetById(id);
		}
		#endregion

		#region Create
		public async Task<int> CreateAsync(LeaderboardsDuongLnt leaderboards)
		{
			return await _unitOfWork.LeaderboardsDuongLNTRepository.CreateAsync(leaderboards);
		}
		#endregion

		#region Update
		public async Task<int> UpdateAsync(LeaderboardsDuongLnt leaderboards)
		{
			return await _unitOfWork.LeaderboardsDuongLNTRepository.UpdateAsync(leaderboards);
		}
		#endregion

		#region Delete
		public async Task<bool> DeleteAsync(int id)
		{
			var leaderboards = await _unitOfWork.LeaderboardsDuongLNTRepository.GetByIdAsync(id);
			return await _unitOfWork.LeaderboardsDuongLNTRepository.RemoveAsync(leaderboards);
		}
		#endregion

	}
}
