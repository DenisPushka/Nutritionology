using LinqToDB.Mapping;

namespace Nutritionology
{
    /// <summary>
    /// Параметры пользователя.
    /// </summary>
    [Table(Name = "Parameter")]
    public class Parameter
    {
        /// <summary>
        /// Вес (кг).
        /// </summary>
        private int _weight;

        /// <summary>
        /// Рост (см).
        /// </summary>
        private int _height;

        /// <summary>
        /// PK.
        /// </summary>
        [PrimaryKey]
        public Guid ParameterId { get; set; }
        
        /// <summary>
        /// PK.
        /// </summary>
        [Column("GenderId")]
        public Guid GenderId { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        [Association(ThisKey = "GenderId", OtherKey = "GenderId")]
        public Gender Gender { get; set; }

        /// <summary>
        /// Вес (кг).
        /// </summary>
        public int Weight
        {
            get => _weight;
            set
            {
                if (value is < 30 or > 220)
                {
                    throw new ArgumentException(
                        $"Вес должен быть указан в пределах [{30}..{280}], данное значение равно - {value}");
                }

                _weight = value;
            }
        }

        /// <summary>
        /// Рост.
        /// </summary>
        public int Height
        {
            get => _height;
            set
            {
                // TODO ВЫНЕСТИ.
                if (value is < 30 or > 280)
                {
                    throw new ArgumentException(
                        $"Возраст должен быть указан в пределах [{30}..{280}], данное значение равно - {value}");
                }
                _height = value;
            }
        }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age;

        /// <summary>
        /// Вкусовые предпочтения.
        /// </summary>
        public List<Product> LikeProducts { get; set; }
        
        /// <summary>
        /// Проблемные продукты.
        /// </summary>
        public List<Product> ProblemProducts { get; set; }
    }
}