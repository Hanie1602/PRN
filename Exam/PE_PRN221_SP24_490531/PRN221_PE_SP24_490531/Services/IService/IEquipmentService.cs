using Repositories.Entities;

namespace Services.IService
{
	public interface IEquipmentService
	{
		List<Equipment> GetEquipment(string? eqName, int? quantity, bool? sortByName, int? pageIndex = null, int? pageSize = null);

		Equipment GetEquipmentById(int id);

		void Save(Equipment e);

		void Update(Equipment e);

		void Delete(Equipment e);

		int GetTotalEquipment(string? eqName, int? quantity);
	}
}
