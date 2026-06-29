using Microsoft.EntityFrameworkCore;

namespace Cafee_web.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // This creates a "Bookings" table in your SQL database based on our Booking model
        public DbSet<Booking> Bookings { get; set; }
    }
}