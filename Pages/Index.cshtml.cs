using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIDM3312_FINALPROJECT.Models;

namespace CIDM3312_FINALPROJECT.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CIDM3312_FINALPROJECT.Models.Context _context;

        public IndexModel(CIDM3312_FINALPROJECT.Models.Context context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return RedirectToPage("/Tickets/Index");
        }
    }
}
