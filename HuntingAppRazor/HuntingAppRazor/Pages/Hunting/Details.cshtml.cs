using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HuntingAppRazor.Models;

namespace HuntingAppRazor.Pages.Hunting
{
    public class DetailsModel : PageModel
    {
        private readonly HuntingAppRazor.Models.HuntingAppDBContext _context;

        public DetailsModel(HuntingAppRazor.Models.HuntingAppDBContext context)
        {
            _context = context;
        }

        public Users Users { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Users = await _context.Users.FirstOrDefaultAsync(m => m.Uuid == id);

            if (Users == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
