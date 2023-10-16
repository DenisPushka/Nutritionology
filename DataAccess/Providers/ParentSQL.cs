using System.Data;
using System.Data.Common;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
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
        
        /// <summary>
        /// Добавление элементов, используется только для asp net provider.
        /// </summary>
        /// <param name="query">Запрос на добавление.</param>
        protected async Task AddObjectInDb(string query)
        {
            await using var connection = new SqlConnection(Connection);
            var command = new SqlCommand(query, connection);
            
            await DoQuery(connection, command);
        }
        
        /// <summary>
        /// Выполнение запроса, используется для asp net provider.
        /// </summary>
        /// <param name="connection">Объект подключения.</param>
        /// <param name="command">Объект запроса для выпонения команды.</param>
        protected async Task DoQuery(SqlConnection connection, DbCommand command)
        {
            try
            {
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                await connection.CloseAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}