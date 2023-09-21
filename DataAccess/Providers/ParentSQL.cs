using Microsoft.Extensions.Configuration;

namespace DataAccess.Providers
{
    /// <summary>
    /// Родительский класс для всех SQL запросов.
    /// </summary>
    public class ParentSql
    {
        /// <summary>
        /// Строка подключения.
        /// </summary>
        protected readonly string Connection;

        /// <summary>
        /// Конструктор, принимающий источник конфигурации.
        /// </summary>
        /// <param name="config">Источник конфигурации.</param>
        protected ParentSql(IConfiguration config) => Connection = config.GetConnectionString("DefaultConnection");
    }
}