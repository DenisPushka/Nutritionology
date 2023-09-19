namespace Nutritionology
{
    /// <summary>
    /// Параметры пользователя.
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// PK.
        /// </summary>
        public Guid ParameterId { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Вес.
        /// </summary>
        public int Weight { get; set; } // TODO VALIDATION!

        /// <summary>
        /// Рост.
        /// </summary>
        public int Height { get; set; } // TODO VALIDATION!

        // TODO Дописать методические рекомендации.
    }
}
