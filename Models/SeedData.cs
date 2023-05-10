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
                if (context.Tickets.Any() || context.Customers.Any())
                {
                    return;
                }
                
                // Create a list of customers
                var customers = new List<Customer>
                {
                    new Customer
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        Email = "johndoe@example.com",
                        PhoneNumber = 1234567890,
                        PaymentMethod = "Credit Card"
                    },
                    new Customer
                    {
                        FirstName = "Jane",
                        LastName = "Doe",
                        Email = "janedoe@example.com",
                        PhoneNumber = 0987654321,
                        PaymentMethod = "PayPal"
                    },
                    new Customer
                    {
                        FirstName = "Bob",
                        LastName = "Smith",
                        Email = "bobsmith@example.com",
                        PhoneNumber = 0012245671,
                        PaymentMethod = "Credit Card"
                    },
                    new Customer
                    {
                        FirstName = "Sarah",
                        LastName = "Johnson",
                        Email = "sarahjohnson@example.com",
                        PhoneNumber = 0122222231,
                        PaymentMethod = "PayPal"
                    },
                    new Customer
                    {
                        FirstName = "Mike",
                        LastName = "Williams",
                        Email = "mikewilliams@example.com",
                        PhoneNumber = 0112134321,
                        PaymentMethod = "Check"
                    }
                    // Add more customers here
                };

                // Add the customers to the database
                context.Customers.AddRange(customers);
                context.SaveChanges();
                
                // Create a list of tickets
                var tickets = new List<Ticket>();

                // Loop through the customers list and create a new ticket for each customer
                foreach (var customer in customers)
                {
                    var ticket = new Ticket
                    {
                        TicketID = Guid.NewGuid(),
                        Status = TicketStatus.Open,
                        Priority = TicketPriority.High,
                        Type = TicketType.Technical,
                        Description = "Application crashes on startup",
                        TicketHistory = DateTime.Now,
                        Search = "application, crash, startup",
                        Management = "Assigned to developer",
                        CustomerId = customer.Id
                    };

                    tickets.Add(ticket);
                }

                // Add the tickets to the database
                context.Tickets.AddRange(tickets);
                context.SaveChanges();   
            }
        }    
    }
}
