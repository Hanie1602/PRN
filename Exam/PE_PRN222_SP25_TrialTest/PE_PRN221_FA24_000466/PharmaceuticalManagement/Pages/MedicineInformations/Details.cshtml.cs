using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Services.IService;

namespace PharmaceuticalManagement.Pages.MedicineInformations
{
	public class DetailsModel : PageModel
    {
		private readonly IMedicineInformationService _medicineInfoService;

		public DetailsModel(IMedicineInformationService medicineInfoService)
		{
			_medicineInfoService = medicineInfoService;
		}

		public MedicineInformation MedicineInformation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
			//Đọc Cookie xem User đã đăng nhập chưa
			if (Request.Cookies["Account"] == null)
			{
				return RedirectToPage("/Login");
			}

			if (id == null)
			{
				return NotFound();
			}

			MedicineInformation medicine = _medicineInfoService.GetMedicineInformationById((string)id);
			if (medicine == null)
			{
				return NotFound();
			}
			else
			{
				MedicineInformation = medicine;
			}
			return Page();
		}
    }
}
