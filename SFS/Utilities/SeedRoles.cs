using Microsoft.AspNetCore.Identity;
using SFS.Utilities;

public static class SeedRoles
{
    public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
    {
        // Fetch the RoleManager service
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        
            if (!await roleManager.RoleExistsAsync(Roles.Role_Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Role_Admin));
                await roleManager.CreateAsync(new IdentityRole(Roles.Role_Client));
        }
        
    }
}
