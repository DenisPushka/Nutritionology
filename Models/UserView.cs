namespace Nutritionology
{
    /// <summary>
    /// Пользователь для отображения данных на фронте.
    /// </summary>
    public class UserView
    {
        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Роль пользователя.
        /// </summary>
        public UserRole? Role { get; set; }
    }
}
