using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SFS.Models.ViewModels
{
    public class ScheduleVM
    {
        public Schedule Schedule { get; set; } 

        [ValidateNever]
        public IEnumerable<SelectListItem> InstructorList { get; set; }  // Dropdown list for Instructors

        [ValidateNever]
        public IEnumerable<SelectListItem> ClassList { get; set; }  // Dropdown list for Classes
    }
}
