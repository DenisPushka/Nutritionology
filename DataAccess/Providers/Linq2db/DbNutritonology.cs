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
        /// Таблица "СИ".
        /// </summary>
        public ITable<MeasurementSystem> MeasurementSystem => this.GetTable<MeasurementSystem>();

        /// <summary>
        /// Таблица "Элемент МР".
        /// </summary>
        public ITable<MRItem> MRItems => this.GetTable<MRItem>();

        /// <summary>
        /// Таблица "Биологических элементов".
        /// </summary>
        public ITable<BiologicalElement> BiologicalElements => this.GetTable<BiologicalElement>();

        /// <summary>
        /// Таблица "Название продукта".
        /// </summary>
        public ITable<ProductName> ProductNames => this.GetTable<ProductName>();
        
        /// <summary>
        /// Таблица "Продукт".
        /// </summary>
        public ITable<Product> Products => this.GetTable<Product>();
        
        /// <summary>
        /// Таблица "Продукт элементМР Map" 
        /// </summary>
        public ITable<ProductMRItemMap> ProductMItemMaps => this.GetTable<ProductMRItemMap>();
    }
}
