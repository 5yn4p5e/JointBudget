using JointBudgetAPI.JointBudgetModels;
using Microsoft.AspNetCore.Identity;

namespace JointBudgetAPI.Data;

public static class IdentitySeed
{
    /// <summary>
    /// Создаёт роли пользователя и администратора. Каждая роль заполнена одним объектом
    /// </summary>
    /// <param name="serviceProvider">Стандартный набор сервисов</param>
    /// <returns></returns>
    public static async Task CreateUserRoles(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        // Создание ролей администратора и пользователя
        if (await roleManager.FindByNameAsync("admin") == null)
        {
            await roleManager.CreateAsync(new IdentityRole("admin"));
        }
        if (await roleManager.FindByNameAsync("user") == null)
        {
            await roleManager.CreateAsync(new IdentityRole("user"));
        }
        // Создание Администратора
        string adminEmail = "ne0l@ne0l.ru";
        string adminPassword = "1AmAdminHellYeah!";
        if (await userManager.FindByNameAsync(adminEmail) == null)
        {
            User admin = new User { Email = adminEmail, UserName = adminEmail, FamilyGroupId = "NoFamilyGroup"};
            IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "admin");
            }
        }
        // Создание Пользователя
        string userEmail = "ohlegnoway@gmail.com";
        string userPassword = "IAmN0tAdmin!";
        if (await userManager.FindByNameAsync(userEmail) == null)
        {
            User user = new User { Email = userEmail, UserName = userEmail, FamilyGroupId = "NoFamilyGroup"};
            IdentityResult result = await userManager.CreateAsync(user, userPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "user");
            }
        }
    }
}