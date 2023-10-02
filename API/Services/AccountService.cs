using Microsoft.AspNetCore.Identity;
using Nutritionology;
using Validation;

namespace API;

/// <summary>
/// Вспомогательный сервис для контроллера Account. 
/// </summary>
public class AccountService
{
    /// <summary>
    /// Добавление пользователя вместе с ролью.
    /// </summary>
    /// <param name="user">Добавляемый пользователь.</param>
    /// <param name="role">Роль для пользователя.</param>
    /// <param name="userManager">Провайдер для пользователя.</param>
    /// <returns>True - в случае успешной регистрации, инчае - false.</returns>
    public static async Task<bool> CreateUserWithRole(User user, UserRole role, UserManager<User> userManager)
    {
        ValidationHelper.CheckUserForAllField(user);
        ValidationHelper.CheckRole(role);

        user.NormalizedUserName = user.Email!.ToUpper();
        user.PasswordHash = HashHelper.GetHash(user.PasswordHash!);
        var result = await userManager.CreateAsync(user, user.PasswordHash);

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, role.Name!);
            return true;
        }

        return false;
    }
}