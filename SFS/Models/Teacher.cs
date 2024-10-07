using System.ComponentModel.DataAnnotations;

namespace SFS.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Expertise { get; set; } 

        
    }
}
