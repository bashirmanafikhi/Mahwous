using Microsoft.AspNetCore.Identity;

namespace Mahwous.Persistence.Models
{
    public class ApplicationUser : IdentityUser/*<Guid>*/
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Avatar { get; set; }
    }
}
