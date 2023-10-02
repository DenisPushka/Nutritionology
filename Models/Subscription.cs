using LinqToDB.Mapping;

namespace Nutritionology
{
    /// <summary>
    /// Подписка.
    /// </summary>
    [Table(Name = "Subscription")]
    public class Subscription
    {
        /// <summary>
        /// PK.
        /// </summary>
        [PrimaryKey]
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        [Column(Name = "Name")]
        public string? Name { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        [Column(Name = "Price")]
        public int? Price { get; set; }
    }
}
