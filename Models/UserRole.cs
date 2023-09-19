using Microsoft.AspNetCore.Identity;

namespace Nutritionology
{
    /// <summary>
    /// Роль пользователя.
    /// </summary>
    public class UserRole: IdentityRole<Guid>
    {
        public UserRole()
        {
        }

        /// <summary>
        /// Конструктор принимающий название роли.
        /// </summary>
        /// <param name="name">Название роли.</param>
        public UserRole(string name)
            : base(name)
        {
        }
    }
}
