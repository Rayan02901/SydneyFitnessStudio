using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SFS.Models;

namespace SFS.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Class>().HasData(
                new Class { ClassId = 1, Name = "Pilates", Description = "Focus on precise body movements and alignment for flexibility." },
                new Class { ClassId = 2, Name = "Yoga", Description = "Balance body and mind with guided stretches and breathing." },
                new Class { ClassId = 3, Name = "HIIT", Description = "Boost your stamina with high-intensity interval training." }
            );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { TeacherId = 1, Name = "Emily Green", Expertise = "Yoga" },
                new Teacher { TeacherId = 2, Name = "David White", Expertise = "Pilates" },
                new Teacher { TeacherId = 3, Name = "Sarah Black", Expertise = "HIIT" }
            );

            // Seeding Schedule data with updated times and capacities
            modelBuilder.Entity<Schedule>().HasData(
                new Schedule
                {
                    ScheduleId = 1,
                    StartTime = new DateTime(2024, 9, 10, 8, 0, 0),  // September 10, 2024 at 08:00 AM
                    EndTime = new DateTime(2024, 9, 10, 9, 30, 0),    // September 10, 2024 at 09:30 AM
                    MaxCapacity = 15,
                    ClassId = 1,
                    TeacherId = 2
                },
                new Schedule
                {
                    ScheduleId = 2,
                    StartTime = new DateTime(2024, 9, 11, 10, 30, 0),  // September 11, 2024 at 10:30 AM
                    EndTime = new DateTime(2024, 9, 11, 11, 45, 0),    // September 11, 2024 at 11:45 AM
                    MaxCapacity = 25,
                    ClassId = 2,
                    TeacherId = 1
                },
                new Schedule
                {
                    ScheduleId = 3,
                    StartTime = new DateTime(2024, 9, 12, 13, 0, 0),  // September 12, 2024 at 01:00 PM
                    EndTime = new DateTime(2024, 9, 12, 14, 30, 0),    // September 12, 2024 at 02:30 PM
                    MaxCapacity = 20,
                    ClassId = 3,
                    TeacherId = 3
                }
            );
        }
    }
}
