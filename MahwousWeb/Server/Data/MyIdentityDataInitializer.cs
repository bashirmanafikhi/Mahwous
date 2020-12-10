using MahwousWeb.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace MahwousWeb.Server.Data
{
    public static class MyIdentityDataInitializer
    {

        public static void SeedData(UserManager<ApplicationUser> userManager,
                                         RoleManager<IdentityRole> roleManager)
        {
            //SeedRoles(roleManager);
            SeedUsers(userManager);
        }


        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("admin@mahwous.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin@mahwous.com";
                user.Email = "admin@mahwous.com";
                user.FirstName = "Admin";
                user.LastName = "Mahwous";


                IdentityResult result = userManager.CreateAsync(user, "Aa123456+").Result;

                if (result.Succeeded)
                {
                    //userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (userManager.FindByNameAsync("user@mahwous.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "user@mahwous.com";
                user.Email = "user@mahwous.com";
                user.FirstName = "User";
                user.LastName = "Mahwous";


                IdentityResult result = userManager.CreateAsync(user, "Aa123456+").Result;

                if (result.Succeeded)
                {
                    //userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
