using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SFS.Data;
using SFS.Models;

namespace SFS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Appointment
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Appointments.Include(a => a.Schedule).ThenInclude(a => a.Class).Include(a => a.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Appointment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Schedule)
                .ThenInclude(a => a.Class)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }





        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }
    }
}