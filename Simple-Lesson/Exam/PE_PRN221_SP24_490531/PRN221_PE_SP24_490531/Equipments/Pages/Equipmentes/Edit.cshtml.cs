using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Services.IService;

namespace Equipments.Pages.Equipmentes
{
	public class EditModel : PageModel
    {
		private readonly IEquipmentService _equipmentService;
		private readonly IRoomService _roomService;
		//private readonly IHubContext<SignalrServer> _hubContext;

		public EditModel(IEquipmentService equipmentService, IRoomService roomService)
		{
			_equipmentService = equipmentService;
			_roomService = roomService;
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
			Equipment = equipment;
			ViewData["RoomID"] = new SelectList(_roomService.GetRooms(), "RoomID", "RoomName");
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
			if (Request.Cookies["Account"] != "1")
			{
				TempData["PermissionError"] = "You do not have permission to do this function!";
				return RedirectToPage("/Equipmentes/Index");
			}

			try
			{
				_equipmentService.Update(Equipment);
				//await _hubContext.Clients.All.SendAsync("LoadAllItems"); //Gửi tín hiệu cho All Client
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!EquipmentExists(Equipment.EqID))
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

        private bool EquipmentExists(int id)
        {
			return (_equipmentService.GetEquipmentById((int)id) == null) ? true : false;
		}
    }
}
