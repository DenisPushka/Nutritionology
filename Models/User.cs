using Microsoft.AspNetCore.Identity;

namespace Nutritionology
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User: IdentityUser<Guid>
    {
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
        public List<Parameter> Parameters { get; set; }
        
        /// <summary>
        /// Id пользователя.
        /// </summary>
        public Guid CustomerId { get; set; }
        
        /// <summary>
        /// Пользователь.
        /// </summary>
        public Customer Customer { get; set; }
        
        /// <summary>
        /// Id компании.
        /// </summary>
        public Guid CompanyId { get; set; }
        
        /// <summary>
        /// Компания.
        /// </summary>
        public Company Company { get; set; }
    }
}
