using LinqToDB;
using LinqToDB.Data;
using Nutritionology;

namespace DataAccess.Providers
{
    /// <summary>
    /// База данных "Нутрициология".
    /// </summary>
    public class DbNutritonology: DataConnection
    {
        /// <summary>
        /// Инициализация.
        /// </summary>
        /// <param name="connectionString">Строка подключения.</param>
        public DbNutritonology(string connectionString)
            : base(ProviderName.SqlServer2019, connectionString)
        {
        }

        /// <summary>
        /// Таблица СИ.
        /// </summary>
        public ITable<MeasurementSystem> MeasurementSystem => this.GetTable<MeasurementSystem>();

        /// <summary>
        /// Таблица элементов МР.
        /// </summary>
        public ITable<MRItem> MRItems => this.GetTable<MRItem>();

        /// <summary>
        /// Таблица биологических элементов.
        /// </summary>
        public ITable<BiologicalElement> BiologicalElements => this.GetTable<BiologicalElement>();
    }
}
