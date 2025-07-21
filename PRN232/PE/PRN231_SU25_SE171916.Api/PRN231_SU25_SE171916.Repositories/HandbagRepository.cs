using Microsoft.EntityFrameworkCore;
using PRN231_SU25_SE171916.Repositories.Basic;
using PRN231_SU25_SE171916.Repositories.Models;

namespace PRN231_SU25_SE171916.Repositories
{
	public class HandbagRepository : GenericRepository<Handbag>
	{
		public HandbagRepository() { }

		public HandbagRepository(Summer2025HandbagDbContext context)
			=> _context = context;

		public async Task<List<Handbag>> GetAllAsync()
		{
			var bags = await _context.Handbags
				.Include(h => h.Brand)
				.ToListAsync();

			return bags;
		}

		public async Task<Handbag?> GetByIdAsync(int id)
		{
			var bag = await _context.Handbags
				.Include(h => h.Brand)
				.FirstOrDefaultAsync(h => h.HandbagId == id);

			return bag;
		}

		public async Task<List<Handbag>> SearchAsync(string modelName, string material)
		{
			var bags = await _context.Handbags
				.Include(h => h.Brand)
				.Where(h =>
				(h.ModelName.ToLower().Contains(modelName.ToLower().Trim()) || string.IsNullOrEmpty(modelName))
				&&
				(!string.IsNullOrEmpty(h.Material) && (h.Material.ToLower().Contains(material.ToLower().Trim()) || string.IsNullOrEmpty(material)))
				).ToListAsync();
			return bags;
		}
	}
}
