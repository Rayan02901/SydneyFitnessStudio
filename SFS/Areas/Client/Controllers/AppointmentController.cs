using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SFS.Data;
using SFS.Models;
using SFS.Utilities;

namespace SFS.Areas.Client.Controllers
{
    [Area("Client")]
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AppointmentController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Client/Appointment
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            var applicationDbContext = _context.Appointments
                .Where(a => a.ApplicationUserId == userId)
                .Include(a => a.Schedule)
                .ThenInclude(a => a.Class)
                .Include(a => a.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Client/Appointment/Details/5
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

        // GET: Client/Appointment/Create
        public IActionResult Create(int? scheduleId)
        {
            ViewData["ScheduleId"] = scheduleId;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["ApplicationUserId"] = userId;
            var schedule = _context.Schedules.Include("Class").FirstOrDefault(s => s.ScheduleId == scheduleId);
            ViewData["ClassName"] = schedule.Class.Name;
            ViewData["StartTime"] = schedule.StartTime;
            ViewData["EndTime"] = schedule.EndTime;
            //ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentId,ScheduleId,ApplicationUserId,AppointmentDate")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "ScheduleId", "ScheduleId", appointment.ScheduleId);
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", appointment.ApplicationUserId);
            return View(appointment);
        }

        // GET: Client/Appointment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "ScheduleId", "ScheduleId", appointment.ScheduleId);
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", appointment.ApplicationUserId);
            return View(appointment);
        }

        // POST: Client/Appointment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,ScheduleId,ApplicationUserId,AppointmentDate")] Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AppointmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "ScheduleId", "ScheduleId", appointment.ScheduleId);
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", appointment.ApplicationUserId);
            return View(appointment);
        }

        // GET: Client/Appointment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Schedule)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Client/Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }
    }
}
