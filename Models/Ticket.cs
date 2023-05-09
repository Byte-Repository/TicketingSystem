using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CIDM3312_FINALPROJECT.Models
{
        public enum TicketStatus
    {
        Open,
        InProgress,
        Resolved,
        Closed
    }

    public enum TicketPriority
    {
        Low,
        Medium,
        High
    }

    public enum TicketType
    {
        Technical,
        Billing,
        General
    }

    public class Ticket
    {
        public Guid TicketID { get; set; }

        [EnumDataType(typeof(TicketStatus))]
        [Required]
        public TicketStatus Status { get; set; }

        [EnumDataType(typeof(TicketPriority))]
        [Required]
        public TicketPriority Priority { get; set; }

        [EnumDataType(typeof(TicketType))]
        [Required]
        public TicketType Type { get; set; }

        [Required]
        public string? Description { get; set; }

        public DateTime TicketHistory { get; set; }

        public string? Search { get; set; }

        public string? Management { get; set; }

        [ForeignKey("Customer")]

        public int CustomerId { get; set; }

        public Customer? Customers { get; set; }

    }
}