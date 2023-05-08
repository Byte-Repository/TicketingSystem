using Microsoft.EntityFrameworkCore;

//Here we have the database context file
namespace CIDM3312_FINALPROJECT.Models
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
            {
            }
                public DbSet<Ticket> Tickets {get; set;} = default!;
                public DbSet<Customer> Customers {get; set;} = default!;
    }
}