using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using CIDM3312_FINALPROJECT.Models;
using System.Collections.Generic;

namespace CIDM3312_FINALPROJECT.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                // Check if any data already exists in the database
                if (context.Tickets.Any())
                {
                    return;
                }

                // Create some customer objects
                var customer1 = new Customer
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe@example.com",
                    PhoneNumber = 1234567890,
                    PaymentMethod = "Credit Card"
                };

                var customer2 = new Customer
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "janedoe@example.com",
                    PhoneNumber = 0987654321,
                    PaymentMethod = "PayPal"
                };

                // Add some tickets with customers
                var tickets = new List<Ticket>
                {
                    new Ticket
                    {
                        TicketID = Guid.Parse("1"),
                        Status = TicketStatus.Open,
                        Priority = TicketPriority.High,
                        Type = TicketType.Technical,
                        Description = "Application crashes on startup",
                        TicketHistory = "User reported issue via email",
                        Search = "application, crash, startup",
                        Management = "Assigned to developer",
                        Customers = new List<Customer> { customer1 }
                    },

                    new Ticket
                    {
                        TicketID = Guid.Parse("2"),
                        Status = TicketStatus.Closed,
                        Priority = TicketPriority.Low,
                        Type = TicketType.General,
                        Description = "Add support for dark mode",
                        TicketHistory = "User requested feature via support chat",
                        Search = "feature, dark mode",
                        Management = "Implemented in latest release",
                        Customers = new List<Customer> { customer2 }
                    }
                };

                // Add the tickets to the database
                context.Tickets.AddRange(tickets);
                context.SaveChanges();
            }
        }
    }
}
