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
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            //todo
        }
    }
}
