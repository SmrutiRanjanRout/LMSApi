using Microsoft.AspNetCore.Identity;

namespace LMS.Model.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
