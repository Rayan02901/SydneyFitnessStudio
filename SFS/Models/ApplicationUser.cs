using Microsoft.AspNetCore.Identity;

namespace SFS.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? age { get; set; }

    }
}
