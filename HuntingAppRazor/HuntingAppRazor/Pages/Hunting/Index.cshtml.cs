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
    public class IndexModel : PageModel
    {
        private readonly HuntingAppRazor.Models.HuntingAppDBContext _context;

        public IndexModel(HuntingAppRazor.Models.HuntingAppDBContext context)
        {
            _context = context;
        }

        public IList<Users> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
