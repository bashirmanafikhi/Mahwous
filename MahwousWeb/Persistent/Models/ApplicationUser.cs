using Microsoft.AspNetCore.Identity;

namespace MahwousWeb.Persistent.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Avatar { get; set; }
    }
}
