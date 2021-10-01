using MahwousWeb.Persistent.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Mahwous.API.Helpers
{
    public static class MyIdentityDataInitializer
    {

        public static void SeedData(UserManager<ApplicationUser> userManager,
                                         RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager).Wait();
            SeedUsers(userManager).Wait();
        }


        public static async Task SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (await userManager.FindByNameAsync("admin@mahwous.com") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin@mahwous.com";
                user.Email = "admin@mahwous.com";
                user.FirstName = "مدير";
                user.LastName = "مهووس";


                IdentityResult result = await userManager.CreateAsync(user, "Aa123456+");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "مدير");
                }
            }

            if (await userManager.FindByNameAsync("user@mahwous.com") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "user@mahwous.com";
                user.Email = "user@mahwous.com";
                user.FirstName = "مستخدم";
                user.LastName = "مهووس";


                IdentityResult result = await userManager.CreateAsync(user, "Aa123456+");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "مستخدم");
                }
            }
        }

        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!(await roleManager.RoleExistsAsync("مدير")))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "مدير";
                IdentityResult roleResult = await roleManager.CreateAsync(role);
            }

            if (!(await roleManager.RoleExistsAsync("مستخدم")))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "مستخدم";
                IdentityResult roleResult = await roleManager.CreateAsync(role);
            }
        }
    }
}
