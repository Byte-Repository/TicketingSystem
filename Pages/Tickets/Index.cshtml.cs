using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIDM3312_FINALPROJECT.Data;
using CIDM3312_FINALPROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;




namespace CIDM3312_FINALPROJECT.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        private readonly CIDM3312_FINALPROJECT.Models.Context _context;

        public IndexModel(CIDM3312_FINALPROJECT.Models.Context context)
        {
            _context = context;
        }

        public IList<Ticket> Tickets { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Options { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SelectedValue { get; set; }
        public string? SortOrder { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public async Task OnGetAsync(string sortOrder, string searchString, int? pageIndex)
        {
            // Set sort order
            SortOrder = sortOrder;

            // Filter by search string
            SearchString = searchString;

            // Define query
            IQueryable<Ticket> ticketsIQ = _context.Tickets;

            // Filter by search string
            if (!string.IsNullOrEmpty(searchString))
            {
                ticketsIQ = ticketsIQ.Where(t => t.Description!.Contains(searchString));
            }

            // Set sort order
            switch (sortOrder)
            {
                case "ticketName_desc":
                    ticketsIQ = ticketsIQ.OrderByDescending(t => t.Description);
                    break;
                default:
                    ticketsIQ = ticketsIQ.OrderBy(t => t.Description);
                    break;
            }

            // Pagination
            const int pageSize = 5;

            Tickets = await PaginatedList<Ticket>.CreateAsync(
                ticketsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            // Select list options
            Options = new SelectList(new Dictionary<string, string>
            {
                { "ticketName_asc", "Tickets Name (A-Z)" },
                { "ticketName_desc", "Tickets Name (Z-A)" }
            }, "Key", "Value", SelectedValue);

            // Set page index and total pages
            PageIndex = pageIndex ?? 1;
            TotalPages = Tickets.TotalPages;
        }
    }
}
