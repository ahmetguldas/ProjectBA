using ApplicationCore.Constants;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            await roleManager.CreateAsync(new IdentityRole(AuthorizationConstants.Roles.ADMINISTRATOR));
            //todo
            var demoUser = new ApplicationUser()
            {
                UserName = AuthorizationConstants.DEFAULT_DEMO_USER,
                Email = AuthorizationConstants.DEFAULT_DEMO_USER,
                EmailConfirmed = true
            };
            await userManager.CreateAsync(demoUser, AuthorizationConstants.DEFAULT_PASSWORD);
            var adminUser = new ApplicationUser()
            {
                UserName = AuthorizationConstants.DEFAULT_ADMIN_USER,
                Email = AuthorizationConstants.DEFAULT_ADMIN_USER,
                EmailConfirmed = true
            };
            await userManager.CreateAsync(adminUser, AuthorizationConstants.DEFAULT_PASSWORD);
            await userManager.AddToRoleAsync(adminUser, AuthorizationConstants.Roles.ADMINISTRATOR);

        }
    }
}
