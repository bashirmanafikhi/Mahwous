using MahwousWeb.Server.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahwousWeb.Server.Data
{
    public static class MyIdentityDataInitializer
    {

        public static void SeedData (UserManager<ApplicationUser> userManager/*,
                                         RoleManager<IdentityRole> roleManager*/)
        {
            //SeedRoles(roleManager);
            SeedUsers(userManager);
        }



        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("admin@admin.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin@admin.com";
                user.Email = "admin@admin.com";
                user.FirstName = "Mahwous";
                user.LastName = "Admin";


                IdentityResult result = userManager.CreateAsync
                (user, "Aa123456+").Result;

                if (result.Succeeded)
                {
                    //userManager.AddToRoleAsync(user, "NormalUser").Wait();
                }
            }
        }

        /*public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("NormalUser").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "NormalUser";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }*/
    }
}
