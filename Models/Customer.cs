using System.ComponentModel.DataAnnotations;

namespace CIDM3312_FINALPROJECT.Models
{
    //Customer information to be able to identify various customers via FirstName, LastName, Email, PhoneNumber, PaymentMethod
    public class Customer
    {
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string? FirstName {get; set;}
        
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string? LastName {get; set;}
        
        [Required]
        [EmailAddress]
        public string? Email {get; set;}
        
        [RegularExpression(@"^[2-9]\d{2}-\d{3}-\d{4}$", ErrorMessage = "Invalid phone number format.")]
        [Required]
        public int PhoneNumber {get; set;}

        [Required]
        public string? PaymentMethod {get; set;}
       
        // Navigation property for tickets
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
        
}