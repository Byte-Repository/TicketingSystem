using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIDM3312_FINALPROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CIDM3312_FINALPROJECT.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        private readonly Context _context;

        public IndexModel(Context context)
        {
            _context = context;
        }

        public IList<Ticket> Tickets { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Options { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SelectedValue { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SortOrder { get; set; } 
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public async Task OnGetAsync(string sortOrder, string searchString, int? pageIndex)
        {
            // Set sort order
            sortOrder ??= "ticketName_asc";

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
            const int pageSize = 10;

            PaginatedList<Ticket> paginatedTickets;

            if (pageIndex.HasValue && pageIndex > 0)
            {
                paginatedTickets = await PaginatedList<Ticket>.CreateAsync(
                    ticketsIQ.AsNoTracking(), pageIndex.Value, pageSize);
            }
            else
            {
                paginatedTickets = await PaginatedList<Ticket>.CreateAsync(
                    ticketsIQ.AsNoTracking(), 1, pageSize);
            }

            Tickets = paginatedTickets;

            // Set page index and total pages
            PageIndex = paginatedTickets.PageIndex;
            TotalPages = paginatedTickets.TotalPages;

            // Select list options
            Options = new SelectList(new Dictionary<string, string>
            {
                { "ticketName_asc", "Tickets Name (A-Z)" },
                { "ticketName_desc", "Tickets Name (Z-A)" }
            }, "Key", "Value", SelectedValue);
        }
    }

    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
