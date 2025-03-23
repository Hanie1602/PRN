using Repositories.Entities;

namespace Services.IService
{
	public interface IMedicineInformationService
	{
		List<MedicineInformation> GetMedicineInformations(string? activeIngredients, string? expirationDate, string? warnings, bool? sortByName, int? pageIndex = null, int? pageSize = null);

		MedicineInformation GetMedicineInformationById(string id);

		void Save(MedicineInformation m);

		void Update(MedicineInformation m);

		void Delete(MedicineInformation m);

		int GetTotalMedicineInformations(string? activeIngredients, string? expirationDate, string? warnings);
	}
}
