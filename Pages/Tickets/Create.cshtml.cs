using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIDM3312_FINALPROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CIDM3312_FINALPROJECT.Pages.Tickets
{
    public class CreateModel : PageModel
    {
        private readonly CIDM3312_FINALPROJECT.Models.Context _context;

        public CreateModel(CIDM3312_FINALPROJECT.Models.Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Ticket? Ticket { get; set; } // Make nullable

        public List<SelectListItem>? CustomerList { get; set; } // Make nullable

        public IActionResult OnGet()
        {
            PopulateCustomerList();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                PopulateCustomerList();
                return Page();
            }

            if (Ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Add(Ticket);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }

        private void PopulateCustomerList()
        {
            CustomerList = _context.Customers
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.FirstName} {c.LastName}"
                })
                .ToList();
        }
    }
}
