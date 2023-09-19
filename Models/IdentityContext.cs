using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Nutritionology
{
    public class IdentityContext: IdentityDbContext<User, UserRole, Guid>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
        {
        }

        /// <summary>
        /// Параметры пользователя.
        /// </summary>
        public DbSet<Parameter> Parameters { get; set; }

        /// <summary>
        /// Подписка.
        /// </summary>
        public DbSet<Subscription> Subscriptions { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        public DbSet<Gender> Genders { get; set; }
    }
}
