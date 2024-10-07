using System.ComponentModel.DataAnnotations;
namespace SFS.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        [Required(ErrorMessage= "Class Name field cannot be empty")]
        [StringLength(50, ErrorMessage = "Classname cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description field cannot be empty")]
        [StringLength(500, ErrorMessage = "Description must be below 500 character")]
        public string Description { get; set; }

        
    }
}
