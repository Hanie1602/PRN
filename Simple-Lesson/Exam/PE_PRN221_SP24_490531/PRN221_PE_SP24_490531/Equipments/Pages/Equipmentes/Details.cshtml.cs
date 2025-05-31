using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Services.IService;

namespace Equipments.Pages.Equipmentes
{
	public class DetailsModel : PageModel
    {
		private readonly IEquipmentService _equipmentService;

		public DetailsModel(IEquipmentService equipmentService)
		{
			_equipmentService = equipmentService;
		}

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
    }
}
