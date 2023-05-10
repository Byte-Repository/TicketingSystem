using CIDM3312_FINALPROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CIDM3312_FINALPROJECT.Pages.Tickets
{
    public class EditModel : PageModel
    {
        private readonly CIDM3312_FINALPROJECT.Models.Context _context;

        public EditModel(CIDM3312_FINALPROJECT.Models.Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Ticket? Ticket { get; set; }

        public List<Customer>? Customers { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket = await _context.Tickets.FirstOrDefaultAsync(m => m.TicketID == id);

            if (Ticket == null)
            {
                return NotFound();
            }

            Customers = await _context.Customers.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ticket!).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(Ticket!.TicketID))
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

        private bool TicketExists(Guid id)
        {
            return _context.Tickets.Any(e => e.TicketID == id);
        }
    }
}
