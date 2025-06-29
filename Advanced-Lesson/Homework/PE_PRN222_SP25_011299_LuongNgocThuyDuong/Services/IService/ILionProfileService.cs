using Repositories.Entities;

namespace Services.IService
{
	public interface ILionProfileService
	{
		List<LionProfile> GetLionProfile(bool? sortByName, int? pageIndex = null, int? pageSize = null);

		LionProfile GetLionProfileById(int id);

		void Save(LionProfile l);

		void Update(LionProfile l);

		void Delete(LionProfile l);

		int GetTotalLionProfile(string? lionName, string? lionTypeName);
	}
}
