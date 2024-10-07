using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SFS.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public int ScheduleId { get; set; }

        [ForeignKey("ScheduleId")]
        [ValidateNever]
        public Schedule Schedule { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser User { get; set; } 


        [Required]
        public DateTime AppointmentDate { get; set; }

        
    }
}
