using PRN231_SU25_SE171916.Repositories.Models;

namespace PRN231_SU25_SE171916.Services
{
    public interface IHandbagService
    {
        Task<int> CreateAsync(Handbag bag);
        Task<bool> DeleteAsync(int id);
        Task<List<Handbag>> GetAllAsync();
        Task<Handbag> GetByIdAsync(int id);
        Task<List<Handbag>> SearchAsync(string modelName, string material);
        Task<int> UpdateAsync(Handbag bag);
    }
}
