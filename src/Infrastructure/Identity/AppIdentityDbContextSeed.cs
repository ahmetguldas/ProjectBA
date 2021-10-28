using ApplicationCore.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
   public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(AuthorizationConstants.Roles.ADMIN))
            {
                await roleManager.CreateAsync(new IdentityRole(AuthorizationConstants.Roles.ADMIN));
            }

            string adminEmail = "admin@example.com";
            if (!await userManager.Users.AnyAsync(x => x.UserName == adminEmail))
            {
                var adminUser = new ApplicationUser() { UserName = adminEmail, Email = adminEmail };
                await userManager.CreateAsync(adminUser, AuthorizationConstants.DEFAULT_PASSWORD);
                await userManager.AddToRoleAsync(adminUser, AuthorizationConstants.Roles.ADMIN);
            }
        }
    }
}
