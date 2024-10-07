using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFS.Data;
using SFS.Models;
using SFS.Models.ViewModels;
using SFS.Utilities;
using System.Linq;
using System.Threading.Tasks;

namespace SFS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.Role_Admin)]
    public class SummaryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SummaryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Summary
        public async Task<IActionResult> Index()
        {

            var scheduleSummary = await _context.Schedules
                .Include(s => s.Class)
                .Include(s => s.Teacher)
                .Select(s => new ScheduleSummaryViewModel
                {
                    ScheduleId = s.ScheduleId,
                    ClassName = s.Class.Name,
                    TeacherName = s.Teacher.Name,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    AppointmentCount = _context.Appointments.Count(a => a.ScheduleId == s.ScheduleId)
                })
                .ToListAsync();

            return View(scheduleSummary);


        }
    }
}
