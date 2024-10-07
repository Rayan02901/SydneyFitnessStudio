using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFS.Data;
using SFS.Models;
using System.Diagnostics;

namespace SFS.Areas.Client.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Fetch all schedules with associated Class and Instructor
            IEnumerable<Schedule> scheduleList = _context.Schedules.Include(s => s.Class).Include(s => s.Teacher);
            return View(scheduleList);

        }

        public async Task<IActionResult> Details(int? scheduleId)
        {
            // Fetch the schedule by ID, including related Class and Instructor entities
            var schedule = await _context.Schedules
                .Include(s => s.Class)
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.ScheduleId == scheduleId);

            if (schedule == null)
            {
                return NotFound();  // Handle case where schedule is not found
            }

            return View(schedule);  // Pass the schedule to the details view
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
