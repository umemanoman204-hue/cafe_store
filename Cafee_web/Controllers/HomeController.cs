using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cafee_web.Models;

namespace Cafee_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Visual Studio will automatically pass our database configuration here
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }

        // 1. This displays the empty Booking form page when someone navigates to it
        [HttpGet]
        public IActionResult Booking()
        {
            return View();
        }
       

        // 2. This runs when the user clicks "Confirm Reservation" button to save data
        [HttpPost]
        public IActionResult Booking(Booking model)
        {
            if (ModelState.IsValid)
            {
                // Adds the form input data straight to the SQL table cache
                _context.Bookings.Add(model);

                // Commits the changes permanently to your local SQL Server
                _context.SaveChanges();

                // Redirects back to the home page with a confirmation or simply refreshes
                return RedirectToAction("Booking", new { success = true });
            }

            // If the user filled it out wrong, send them back to fix it
            return View(model);
        }
        // This controls the secure dashboard view where all database bookings are listed
        public IActionResult AdminDashboard()
        {
            // Fetches the entire list of reservations directly from the SQL database
            var allBookings = _context.Bookings.OrderByDescending(b => b.ReservationDate).ToList();

            // Sends the database list to the frontend layout screen
            return View(allBookings);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}