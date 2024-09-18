using Assignmen2.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Assignmen2.Data
{
    public static class DbSeeder
    {
        public static async Task Seed(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Initialize SeedUsersRoles to get predefined roles, users, and user-role mappings
            var seedUsersRoles = new SeedUsersRoles();

            // Seed Roles
            foreach (var role in seedUsersRoles.Roles)
            {
                if (!await roleManager.RoleExistsAsync(role.Name))
                {
                    var result = await roleManager.CreateAsync(role);
                    if (!result.Succeeded)
                    {
                        // Handle role creation errors (optional logging can be added)
                        continue;
                    }
                }
            }

            // Seed Users
            foreach (var user in seedUsersRoles.Users)
            {
                var existingUser = await userManager.FindByEmailAsync(user.Email);
                if (existingUser == null)
                {
                    // Create user
                    var result = await userManager.CreateAsync(user, "P@$$w0rd");
                    if (!result.Succeeded)
                    {
                        // Handle user creation errors (optional logging can be added)
                        continue;
                    }
                }
            }

            // Assign Roles to Users
            foreach (var userRole in seedUsersRoles.UserRoles)
            {
                // Find user and role by their Ids
                var user = await userManager.FindByIdAsync(userRole.UserId);
                var role = await roleManager.FindByIdAsync(userRole.RoleId);

                if (user != null && role != null)
                {
                    // Check if the user is already assigned the role
                    if (!await userManager.IsInRoleAsync(user, role.Name))
                    {
                        var result = await userManager.AddToRoleAsync(user, role.Name);
                        if (!result.Succeeded)
                        {
                            // Handle role assignment errors (optional logging can be added)
                            continue;
                        }
                    }
                }
            }
        }
    }
}
