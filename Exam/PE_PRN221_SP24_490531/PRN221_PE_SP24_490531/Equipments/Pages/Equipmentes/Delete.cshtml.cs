using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Services.IService;

namespace Equipments.Pages.Equipmentes
{
	public class DeleteModel : PageModel
    {
		private readonly IEquipmentService _equipmentService;
		//private readonly IHubContext<SignalrServer> _hubContext;

		public DeleteModel(IEquipmentService equipmentService)
		{
			_equipmentService = equipmentService;
			//_hubContext = hubContext;
		}

		[BindProperty]
        public Equipment Equipment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
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
			if (Request.Cookies["Account"] != "1")
			{
				TempData["PermissionError"] = "You do not have permission to do this function!";
				return RedirectToPage("/Equipmentes/Index");
			}

			Equipment equipment = _equipmentService.GetEquipmentById((int)id);

			if (equipment == null)
			{
				return NotFound();
			}
			else
			{
				Equipment = equipment;
			}
			return Page();
		}

        public async Task<IActionResult> OnPostAsync(int? id)
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
			if (Request.Cookies["Account"] != "1")
			{
				TempData["PermissionError"] = "You do not have permission to do this function!";
				return RedirectToPage("/Equipmentes/Index");
			}

			Equipment equipment = _equipmentService.GetEquipmentById((int)id);
			if (equipment != null)
			{
				Equipment = equipment;
				_equipmentService.Delete(equipment);
				//await _hubContext.Clients.All.SendAsync("LoadAllItems"); //Gửi tín hiệu cho All Client
			}

			return RedirectToPage("./Index");
		}
    }
}
