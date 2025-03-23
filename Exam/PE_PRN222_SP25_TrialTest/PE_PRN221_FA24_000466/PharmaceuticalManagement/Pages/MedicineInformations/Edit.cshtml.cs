using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Services.IService;

namespace PharmaceuticalManagement.Pages.MedicineInformations
{
	public class EditModel : PageModel
    {
		private readonly IMedicineInformationService _medicineInfoService;
		private readonly IManufacturerService _manufacturerService;
		//private readonly IHubContext<SignalrServer> _hubContext;

		public EditModel(IMedicineInformationService medicineInfoService, IManufacturerService manufacturerService)
		{
			_medicineInfoService = medicineInfoService;
			_manufacturerService = manufacturerService;
			//_hubContext = hubContext;
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
			MedicineInformation = medicine;
			ViewData["ManufacturerID"] = new SelectList(_manufacturerService.GetManufactureres(), "ManufacturerID", "ManufacturerName");
			return Page();
		}

        // To protect from overposting attacks, enable the specific properties you want to bind to.
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

			try
			{
				_medicineInfoService.Update(MedicineInformation);
				//await _hubContext.Clients.All.SendAsync("LoadAllItems"); //Gửi tín hiệu cho All Client
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MedicineInformationExists(MedicineInformation.MedicineID))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return RedirectToPage("./Index");
		}

        private bool MedicineInformationExists(string id)
        {
			return (_medicineInfoService.GetMedicineInformationById((string)id) == null) ? true : false;
		}
    }
}
