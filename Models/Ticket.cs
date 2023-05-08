using System.ComponentModel.DataAnnotations;

namespace CIDM3312_FINALPROJECT.Models
{
    public class Ticket
    {
        public int TicketID {get; set;}
        [StringLength(60, MinimumLength = 1)]
        [Required]

        public string? Status {get; set;}

        public string? Priority {get; set;}

        public string? Type {get; set;}

        public string? Description {get; set;}
        [Required]

        public string? TicketHistory {get; set;}

        public string? Search {get; set;}

        public string? Management {get; set;}


    }
        
}