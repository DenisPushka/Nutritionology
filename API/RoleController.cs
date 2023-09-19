using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nutritionology;

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
        private RoleManager<UserRole> _roleManager { get; set; }

        public RoleController(RoleManager<UserRole> roleManager)
        {
            _roleManager = roleManager;
        }

        /// <summary>
        /// Добавление роли.
        /// </summary>
        /// <param name="role">Добавляемая роль.</param>
        /// <returns>Список ролей.</returns>
        [HttpPost, Route("AddRole")]
        public async Task<IActionResult> AddRole(UserRole role)
        {
            //TODO Validation.

            if (await _roleManager.FindByNameAsync(role.Name) == null)
            {
                await _roleManager.CreateAsync(new UserRole(role.Name));
            }

            return Ok(_roleManager.Roles);
        }
    }
}
