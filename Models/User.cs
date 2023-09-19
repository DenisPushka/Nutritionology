using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Nutritionology
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User: IdentityUser<Guid>
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Фото.
        /// </summary>
        public byte[]? Photo { get; set; }

        /// <summary>
        /// Подписка.
        /// </summary>
        public Subscription? Subscription { get; set; }

        /// <summary>
        /// Параметры для пользователя.
        /// </summary>
        public Parameter? Parameter { get; set; }
    }
}
