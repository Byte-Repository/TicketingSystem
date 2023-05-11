using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIDM3312_FINALPROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CIDM3312_FINALPROJECT.Pages.Tickets
{
    public class DeleteModel : PageModel
    {
        private readonly CIDM3312_FINALPROJECT.Models.Context _context;

        public DeleteModel(CIDM3312_FINALPROJECT.Models.Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Ticket? Ticket { get; set; } // Make nullable

        public IActionResult OnGet(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket = _context.Tickets.FirstOrDefault(t => t.TicketID == id);

            if (Ticket == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (Ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(Ticket);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
