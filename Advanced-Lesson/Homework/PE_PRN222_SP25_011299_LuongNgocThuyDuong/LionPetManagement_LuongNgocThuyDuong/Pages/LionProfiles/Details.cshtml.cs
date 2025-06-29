using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repositories.Entities;

namespace LionPetManagement_LuongNgocThuyDuong.Pages.LionProfiles
{
    public class DetailsModel : PageModel
    {
        private readonly Repositories.Entities.SP25LionDBContext _context;

        public DetailsModel(Repositories.Entities.SP25LionDBContext context)
        {
            _context = context;
        }

        public LionProfile LionProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lionprofile = await _context.LionProfiles.FirstOrDefaultAsync(m => m.LionProfileId == id);
            if (lionprofile == null)
            {
                return NotFound();
            }
            else
            {
                LionProfile = lionprofile;
            }
            return Page();
        }
    }
}
