using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using NuGet.Common;
using Repositories.Entities;
using Services.IService;
using System.ComponentModel.DataAnnotations;

namespace Equipments.Pages.Equipmentes
{
	public class CreateModel : PageModel
	{
		private readonly IEquipmentService _equipmentService;
		private readonly IRoomService _roomService;
		//private readonly IHubContext<SignalrServer> _hubContext;

		public CreateModel(IEquipmentService equipmentService, IRoomService roomService)
		{
			_equipmentService = equipmentService;
			_roomService = roomService;
			//_hubContext = hubContext;
		}

		public IActionResult OnGet()
		{
			//Đọc Cookie xem User đã đăng nhập chưa
			if (Request.Cookies["Account"] == null)
			{
				return RedirectToPage("/Login");
			}

			//Kiểm tra quyền
			if (Request.Cookies["Account"] != "1") // Không phải Manager
			{
				TempData["PermissionError"] = "You do not have permission to do this function!";
				return RedirectToPage("/Equipmentes/Index");
			}

			ViewData["RoomID"] = new SelectList(_roomService.GetRooms(), "RoomID", "RoomName");
			return Page();
		}

		[BindProperty]
		public Equipment Equipments { get; set; } = default!;

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
			if (Request.Cookies["Account"] != "1")
			{
				TempData["PermissionError"] = "You do not have permission to do this function!";
				return RedirectToPage("/Equipmentes/Index");
			}

			_equipmentService.Save(Equipments);
			//await _hubContext.Clients.All.SendAsync("LoadAllItems"); //Gửi tín hiệu cho All Client

			return RedirectToPage("./Index");
		}

	}
}
