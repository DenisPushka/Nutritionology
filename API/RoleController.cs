using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nutritionology;
using Validation;

namespace API
{
    /// <summary>
    /// Контроллер для работы с ролями.
    /// </summary>
    [ApiController, Route("[controller]")]
    public class RoleController: ControllerBase
    {
        /// <summary>
        /// Провайдер для таблицы ролей.
        /// </summary>
        private RoleManager<UserRole> RoleManager { get; }

        public RoleController(RoleManager<UserRole> roleManager)
        {
            RoleManager = roleManager;
        }

        /// <summary>
        /// Добавление роли.
        /// </summary>
        /// <param name="role">Добавляемая роль.</param>
        /// <returns>Список ролей.</returns>
        [HttpPost, Route("AddRole")]
        public async Task<IActionResult> AddRole(UserRole role)
        {
            ValidationHelper.CheckRole(role);

            if (await RoleManager.FindByNameAsync(role.Name!) == null)
            {
                await RoleManager.CreateAsync(new UserRole(role.Name!));
            }

            return Ok(RoleManager.Roles);
        }
    }
}
