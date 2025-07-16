using PRN231_SU25_SE171916.Repositories.Models;

namespace PRN231_SU25_SE171916.Services
{
    public class HandbagService : IHandbagService
    {
        private readonly IUnitOfWork _unitOfWork;
        public HandbagService() => _unitOfWork ??= new UnitOfWork();

        public async Task<List<Handbag>> GetAllAsync()
        {
            return await _unitOfWork.HandbagRepository.GetAllAsync();
        }

        public async Task<Handbag> GetByIdAsync(int id)
        {
            return await _unitOfWork.HandbagRepository.GetByIdAsync(id);
        }

        public async Task<List<Handbag>> SearchAsync(string modelName, string material)
        {
            return await _unitOfWork.HandbagRepository.SearchAsync(modelName, material);
        }
        public async Task<int> CreateAsync(Handbag bag)
        {
            return await _unitOfWork.HandbagRepository.CreateAsync(bag);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var bag = await _unitOfWork.HandbagRepository.GetByIdAsync(id);
            return await _unitOfWork.HandbagRepository.RemoveAsync(bag);
        }

        public async Task<int> UpdateAsync(Handbag bag)
        {
            return await _unitOfWork.HandbagRepository.UpdateAsync(bag);
        }
    }
}
