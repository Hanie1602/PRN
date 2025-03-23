using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Repositories.Entities;
using Services.IService;

namespace PharmaceuticalManagement.Pages.MedicineInformations
{
	public class CreateModel : PageModel
    {
		private readonly IMedicineInformationService _medicineInfoService;
		private readonly IManufacturerService _manufacturerService;
		//private readonly IHubContext<SignalrServer> _hubContext;
		//IHubContext<SignalrServer> hubContext

		public CreateModel(IMedicineInformationService medicineInfoService, IManufacturerService manufacturerService)
		{
			_medicineInfoService = medicineInfoService;
			_manufacturerService = manufacturerService;
		}

		public IActionResult OnGet()
        {
			//Đọc Cookie xem User đã đăng nhập chưa
			if (Request.Cookies["Account"] == null)
			{
				return RedirectToPage("/Login");
			}

			//Kiểm tra quyền
			if (Request.Cookies["Account"] != "2") // Không phải Manager
			{
				TempData["PermissionError"] = "You do not have permission to do this function!";
				return RedirectToPage("/MedicineInformations/Index");
			}

			ViewData["ManufacturerID"] = new SelectList(_manufacturerService.GetManufactureres(), "ManufacturerID", "ManufacturerName");
			return Page();
		}

        [BindProperty]
        public MedicineInformation MedicineInformation { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
			//Đọc Cookie xem User đã đăng nhập chưa
			if (Request.Cookies["Account"] == null)
			{
				return RedirectToPage("/Login");
			}

			if (!ModelState.IsValid)
			{
				return Page();
			}

			//Kiểm tra quyền
			if (Request.Cookies["Account"] != "2")
			{
				TempData["PermissionError"] = "You do not have permission to do this function!";
				return RedirectToPage("/MedicineInformations/Index");
			}
			
			_medicineInfoService.Save(MedicineInformation);
			//await _hubContext.Clients.All.SendAsync("LoadAllItems"); //Gửi tín hiệu cho All Client

			return RedirectToPage("./Index");
		}
    }
}
