namespace Nutritionology
{
    /// <summary>
    /// Пол.
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// PK.
        /// </summary>
        public Guid GenderId { get; set; }

        /// <summary>
        /// Короткое название.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Полное название.
        /// </summary>
        public string FullName { get; set; }
    }
}
