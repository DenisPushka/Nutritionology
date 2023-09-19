namespace Nutritionology
{
    /// <summary>
    /// Подписка.
    /// </summary>
    public class Subscription
    {
        /// <summary>
        /// PK.
        /// </summary>
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        public int? Price { get; set; }
    }
}
