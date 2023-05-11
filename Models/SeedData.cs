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
                        PhoneNumber = 1122334455,
                        PaymentMethod = "Credit Card"
                    },
                    new Customer
                    {
                        FirstName = "Sarah",
                        LastName = "Johnson",
                        Email = "sarahjohnson@example.com",
                        PhoneNumber = 1111111111,
                        PaymentMethod = "PayPal"
                    },
                    new Customer
                    {
                        FirstName = "Mike",
                        LastName = "Williams",
                        Email = "mikewilliams@example.com",
                        PhoneNumber = 1212221111,
                        PaymentMethod = "Check"
                    },
                    new Customer
                    {
                        FirstName = "Emily",
                        LastName = "Davis",
                        Email = "emilydavis@example.com",
                        PhoneNumber = 1212221111,
                        PaymentMethod = "Credit Card"
                    },
                    new Customer
                    {
                        FirstName = "David",
                        LastName = "Anderson",
                        Email = "davidanderson@example.com",
                        PhoneNumber = 1234567891,
                        PaymentMethod = "PayPal"
                    },
                    new Customer
                    {
                        FirstName = "Olivia",
                        LastName = "Moore",
                        Email = "oliviamoore@example.com",
                        PhoneNumber = 1231231231,
                        PaymentMethod = "Credit Card"
                    },
                    new Customer
                    {
                        FirstName = "Sophia",
                        LastName = "Clark",
                        Email = "sophiaclark@example.com",
                        PhoneNumber = 1234543210,
                        PaymentMethod = "PayPal"
                    },
                    new Customer
                    {
                        FirstName = "Liam",
                        LastName = "Johnson",
                        Email = "liamjohnson@example.com",
                        PhoneNumber = 1122334455,
                        PaymentMethod = "Check"
                    },
                    new Customer
                    {
                        FirstName = "Alice",
                        LastName = "Smith",
                        Email = "alice.smith@example.com",
                        PhoneNumber = 1234567890,
                        PaymentMethod = "Credit Card"
                    },
                    new Customer
                    {
                        FirstName = "Michael",
                        LastName = "Johnson",
                        Email = "michael.johnson@example.com",
                        PhoneNumber = 1234543210,
                        PaymentMethod = "PayPal"
                    },
                    new Customer
                    {
                        FirstName = "Emily",
                        LastName = "Brown",
                        Email = "emily.brown@example.com",
                        PhoneNumber = 1234567891,
                        PaymentMethod = "Credit Card"
                    },
                    new Customer
                    {
                        FirstName = "Daniel",
                        LastName = "Martinez",
                        Email = "daniel.martinez@example.com",
                        PhoneNumber = 1357924680,
                        PaymentMethod = "PayPal"
                    },
                    new Customer
                    {
                        FirstName = "Olivia",
                        LastName = "Davis",
                        Email = "olivia.davis@example.com",
                        PhoneNumber = 1231231231,
                        PaymentMethod = "Check"
                    },
                    new Customer
                    {
                        FirstName = "William",
                        LastName = "Taylor",
                        Email = "william.taylor@example.com",
                        PhoneNumber = 1234321233,
                        PaymentMethod = "Credit Card"
                    },
                    new Customer
                    {
                        FirstName = "Sophia",
                        LastName = "Anderson",
                        Email = "sophia.anderson@example.com",
                        PhoneNumber = 1232344322,
                        PaymentMethod = "PayPal"
                    },
                    new Customer
                    {
                        FirstName = "James",
                        LastName = "Wilson",
                        Email = "james.wilson@example.com",
                        PhoneNumber = 1111231231,
                        PaymentMethod = "Credit Card"
                    },
                    new Customer
                    {
                        FirstName = "Charlotte",
                        LastName = "Thomas",
                        Email = "charlotte.thomas@example.com",
                        PhoneNumber = 1593578520,
                        PaymentMethod = "Check"
                    },
                    new Customer
                    {
                        FirstName = "Benjamin",
                        LastName = "Robinson",
                        Email = "benjamin.robinson@example.com",
                        PhoneNumber = 1111598520,
                        PaymentMethod = "PayPal"
                    },
                    new Customer
                    {
                        FirstName = "Ethan",
                        LastName = "Harris",
                        Email = "ethan.harris@example.com",
                        PhoneNumber = 1236543210,
                        PaymentMethod = "Credit Card"
                    },
                    new Customer
                    {
                        FirstName = "Ava",
                        LastName = "Wilson",
                        Email = "ava.wilson@example.com",
                        PhoneNumber = 1118135790,
                        PaymentMethod = "PayPal"
                    },
                    new Customer
                    {
                        FirstName = "Liam",
                        LastName = "Lee",
                        Email = "liam.lee@example.com",
                        PhoneNumber = 1357924680,
                        PaymentMethod = "Credit Card"
                    },
                    new Customer
                    {
                        FirstName = "Mia",
                        LastName = "Thompson",
                        Email = "mia.thompson@example.com",
                        PhoneNumber = 1118521470,
                        PaymentMethod = "PayPal"
                    },
                    new Customer
                    {
                        FirstName = "Noah",
                        LastName = "Garcia",
                        Email = "noah.garcia@example.com",
                        PhoneNumber = 2133691470,
                        PaymentMethod = "Check"
                    }

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
