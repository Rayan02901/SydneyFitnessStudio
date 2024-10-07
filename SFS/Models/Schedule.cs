using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SFS.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }

        [Required]
        public int ClassId { get; set; }

        [ForeignKey("ClassId")]
        [ValidateNever]
        public Class Class { get; set; }

        [Required]
        public int TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        [ValidateNever]
        public Teacher Teacher { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public int MaxCapacity { get; set; }
    }
}
