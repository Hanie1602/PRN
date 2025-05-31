using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using PharmaceuticalManagement.Signalr;
using Repositories.Entities;
using Services.IService;

namespace PharmaceuticalManagement.Pages.MedicineInformations
{
	public class DeleteModel : PageModel
    {
		private readonly IMedicineInformationService _medicineInfoService;
		private readonly IHubContext<SignalrServer> _hubContext;

		public DeleteModel(IMedicineInformationService medicineInfoService, IHubContext<SignalrServer> hubContext)
		{
			_medicineInfoService = medicineInfoService;
			_hubContext = hubContext;
		}

		[BindProperty]
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

			//Kiểm tra quyền
			if (Request.Cookies["Account"] != "2")
			{
				TempData["PermissionError"] = "You do not have permission to do this function!";
				return RedirectToPage("/MedicineInformations/Index");
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

        public async Task<IActionResult> OnPostAsync(string id)
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

			//Kiểm tra quyền
			if (Request.Cookies["Account"] != "2")
			{
				TempData["PermissionError"] = "You do not have permission to do this function!";
				return RedirectToPage("/MedicineInformations/Index");
			}

			MedicineInformation medicine = _medicineInfoService.GetMedicineInformationById((string)id);
			if (medicine != null)
			{
				MedicineInformation = medicine;
				_medicineInfoService.Delete(medicine);
				await _hubContext.Clients.All.SendAsync("LoadAllItems"); //Gửi tín hiệu cho All Client
			}

			return RedirectToPage("./Index");
		}
    }
}
