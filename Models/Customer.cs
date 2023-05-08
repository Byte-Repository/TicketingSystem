using System.ComponentModel.DataAnnotations;

namespace CIDM3312_FINALPROJECT.Models
{
    //Customer information to be able to identify various customers via FirstName, LastName, Email, PhoneNumber, PaymentMethod
    public class Customer
    {
        public string? FirstName {get; set;}
        [StringLength(30, MinimumLength = 3)]
        [Required]

        public string? LastName {get; set;}
        [StringLength(30, MinimumLength = 3)]
        [Required]

        public string? Email {get; set;}
        [Required]

        public int PhoneNumber {get; set;}
        [Required]
        public string? PaymentMethod {get; set;}
        [Required]

        public List<Ticket> Tickets {get; set;} = new List<Ticket>();

    }
        
}