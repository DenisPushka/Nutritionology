using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Text;
using DataAccess.Providers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Nutritionology;

namespace DataAccess
{
    /// <summary>
    /// Реализатор запросов для МР и прилегающей к ней
    /// словарей (Элемент МР, СИ, Биологический элемент).
    /// </summary>
    public class MRAspNet: ParentSql
    {
        public MRAspNet(IConfiguration config)
            : base(config)
        {
        }

        #region СИ

        /// <summary>
        /// Добавление объекта СИ.
        /// </summary>
        /// <param name="ms">Добавляемый объект.</param>
        public async Task AddMs(MeasurementSystem ms)
        {
            // TODO VALIDATION.
            await using var connection = new SqlConnection(Connection);
            var command = new SqlCommand(SqlScriptsMr.AddMs, connection);
            command.Parameters.AddWithValue("@shortName", ms.ShortName);
            command.Parameters.AddWithValue("@fullName", ms.FullName);

            await DoQuery(connection, command);
        }

        /// <summary>
        /// Добавление массива СИ.
        /// </summary>
        /// <param name="mses">Добавляемый объект.</param>
        public async Task AddArrayMs(IEnumerable<MeasurementSystem> mses)
        {
            // TODO VALIDATION.
            var queryAddMs = new StringBuilder(SqlScriptsMr.AddMsShot);

            foreach (var ms in mses)
            {
                queryAddMs
                    .Append("(\'")
                    .Append(ms.ShortName)
                    .Append("\', \'")
                    .Append(ms.FullName)
                    .Append("\'),");
            }

            queryAddMs.Remove(queryAddMs.Length - 1, 1);

            await AddObjectInDb(queryAddMs.ToString());
        }

        #endregion

        #region Биологический элемент

        /// <summary>
        /// Добавление биологического элемента.
        /// </summary>
        /// <param name="biologicallyElement">Добавляемый объект.</param>
        public async Task AddBiologicallyElement(BiologicalElement biologicallyElement)
        {
            // TODO VALIDATION.
            await using var connection = new SqlConnection(Connection);
            var command = new SqlCommand(SqlScriptsMr.AddBEl, connection);

            command.Parameters.AddWithValue("@shortName", biologicallyElement.ShortName);
            command.Parameters.AddWithValue("@fullName", biologicallyElement.FullName);

            await DoQuery(connection, command);
        }

        /// <summary>
        /// Добавление массива биологических элементов.
        /// </summary>
        /// <param name="biologicallyElements">Добавляемый объект.</param>
        public async Task AddBiologicallyElements(IEnumerable<BiologicalElement> biologicallyElements)
        {
            // TODO VALIDATION.
            var queryAddBiolEl = new StringBuilder(SqlScriptsMr.AddBElShot);

            foreach (var bl in biologicallyElements)
            {
                queryAddBiolEl
                    .Append("(\'")
                    .Append(bl.ShortName)
                    .Append("\', \'")
                    .Append(bl.FullName)
                    .Append("\' ),");
            }

            queryAddBiolEl.Remove(queryAddBiolEl.Length - 1, 1);

            await AddObjectInDb(queryAddBiolEl.ToString());
        }

        #endregion

        #region Элемент МР

        /// <summary>
        /// Добавление элемента МР.
        /// </summary>
        /// <param name="mrItem">Добавляемый объект.</param>
        public async Task AddMrItem(MRItem mrItem)
        {
            // TODO VALIDATION.
            await using var connection = new SqlConnection(Connection);
            var command = new SqlCommand(SqlScriptsMr.AddMrItem, connection);

            command.Parameters.AddWithValue("@name", mrItem.Name);
            command.Parameters.AddWithValue("@msId", mrItem.MeasurementSystem.MSId);
            command.Parameters.AddWithValue("@biologicalElementId", mrItem.BiologicalElement.BiologicalElementId);

            await DoQuery(connection, command);
        }

        /// <summary>
        /// Добавление массива элементов МР.
        /// </summary>
        /// <param name="mrItems">Добавляемый объект.</param>
        public async Task AddMrItems(IEnumerable<MRItem> mrItems)
        {
            // TODO VALIDATION.
            var queryAddMrItems = new StringBuilder(SqlScriptsMr.AddMrItemShot);

            foreach (var mrIt in mrItems)
            {
                queryAddMrItems
                    .Append("(\'")
                    .Append(mrIt.Name)
                    .Append("\', \'")
                    .Append(mrIt.MeasurementSystem.MSId)
                    .Append("\', \'")
                    .Append(mrIt.BiologicalElement.BiologicalElementId)
                    .Append("\'),");
            }

            queryAddMrItems.Remove(queryAddMrItems.Length - 1, 1);

            await AddObjectInDb(queryAddMrItems.ToString());
        }

        /// <summary>
        /// Получение всех элементов МР.
        /// </summary>
        /// <returns>Массив всех элементов МР.</returns>
        public async Task<MRItem[]> GetMrItems()
        {
            var mrItems = new List<MRItem>();

            await using (var connection = new SqlConnection(Connection))
            {
                var command = new SqlCommand(SqlScriptsMr.GetMrItems, connection);

                try
                {
                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        mrItems.Add(new MRItem
                        {
                            MRItemId = (Guid)reader[0],
                            Name = (string)reader[1],
                            MeasurementSystem = new MeasurementSystem { 
                                ShortName = (string)reader[2], 
                                FullName = (string)reader[3]
                            },
                            BiologicalElement = new BiologicalElement
                            {
                                ShortName = (string)reader[4],
                                FullName = reader[5] != null
                                    ? (string)reader[5]
                                    : ""
                            }
                        });
                    }
                }
                catch (SqlException e)
                {
                    Debug.WriteLine(e);
                    throw;
                }
            }

            return mrItems.ToArray();
        }

        #endregion

        #region МР

        /// <summary>
        /// Добавление МР.
        /// </summary>
        /// <param name="mr">Добавляемая МР.</param>
        public async Task AddMr(MR mr)
        {
            // TODO VALIDATION.
            await using var connection = new SqlConnection(Connection);
            var command = new SqlCommand(SqlScriptsMr.AddMr, connection);

            command.Parameters.AddWithValue("@mrItemId", mr.MrItem.MRItemId);
            command.Parameters.AddWithValue("@genderId", mr.Gender.GenderId);
            command.Parameters.AddWithValue("@data", mr.Data);
            command.Parameters.AddWithValue("@startAge", mr.StartAge);
            command.Parameters.AddWithValue("@finishAge", mr.FinishAge);

            await DoQuery(connection, command);
        }

        /// <summary>
        /// Добавление массива МР.
        /// </summary>
        /// <param name="mrs">Добавляемый объект.</param>
        public async Task AddMrs(IEnumerable<MR> mrs)
        {
            // TODO VALIDATION.
            var queryAddMrItems = new StringBuilder(SqlScriptsMr.AddMrShot);

            foreach (var mr in mrs)
            {
                queryAddMrItems
                    .Append("(\'")
                    .Append(mr.MrItem.MRItemId)
                    .Append("\' , \'")
                    .Append(mr.Gender.GenderId)
                    .Append("\', \'")
                    .Append(mr.Data)
                    .Append("\', \'")
                    .Append(mr.StartAge)
                    .Append("\', \'")
                    .Append(mr.FinishAge)
                    .Append("\'),");
            }

            queryAddMrItems.Remove(queryAddMrItems.Length - 1, 1);

            await AddObjectInDb(queryAddMrItems.ToString());
        }

        /// <summary>
        /// Получение всех МР.
        /// </summary>
        /// <returns>Массив всех МР.</returns>
        public async Task<MR[]> GetMrs()
        {
            var mrs = new List<MR>();

            await using (var connection = new SqlConnection(Connection))
            {
                var command = new SqlCommand(SqlScriptsMr.GetMrs, connection);

                try
                {
                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        mrs.Add(new MR
                        {
                            MRId = (Guid)reader[0],
                            MrItem = new MRItem
                            {
                                Name = (string)reader[1],
                                MeasurementSystem = new MeasurementSystem
                                {
                                    ShortName = (string)reader[2],
                                    FullName = (string)reader[3],
                                },
                                BiologicalElement = new BiologicalElement
                                {
                                    ShortName = (string)reader[4],
                                    FullName = (string)reader[5]
                                }
                            },
                            Gender = new Gender
                            {
                                ShortName = (string)reader[6],
                                FullName = (string)reader[7]
                            },
                            Data = (decimal)reader[8],
                            StartAge = (decimal)reader[9],
                            FinishAge = (decimal)reader[10]
                        });
                    }
                }
                catch (SqlException e)
                {
                    Debug.WriteLine(e);
                    throw;
                }
            }

            return mrs.ToArray();
        }

        /// <summary>
        /// Изменение МР.
        /// </summary>
        /// <param name="mr">Измененный объект.</param>
        public async Task UpdateMr(MR mr)
        {
            // TODO VALIDATION.

            await using var connection = new SqlConnection(Connection);
            var command = new SqlCommand(SqlScriptsMr.UpdateMr, connection);
            
            command.Parameters.AddWithValue("@mrItemId", mr.MrItem.MRItemId);
            command.Parameters.AddWithValue("@genderId", mr.Gender.GenderId);
            command.Parameters.AddWithValue("@data", mr.Data);
            command.Parameters.AddWithValue("@startAge", mr.StartAge);
            command.Parameters.AddWithValue("@finishAge", mr.FinishAge);
            command.Parameters.AddWithValue("@mrId", mr.MRId);

            await DoQuery(connection, command);
        }

        #endregion
        
        #region Private Methods

        /// <summary>
        /// Добавление элементов.
        /// </summary>
        /// <param name="query">Запрос на добавление.</param>
        private async Task AddObjectInDb(string query)
        {
            await using var connection = new SqlConnection(Connection);
            var command = new SqlCommand(query, connection);

            await DoQuery(connection, command);
        }

        /// <summary>
        /// Выполнение запроса.
        /// </summary>
        /// <param name="connection">Объект подключения.</param>
        /// <param name="command">Объект запроса для выпонения команды.</param>
        private static async Task DoQuery(IDbConnection connection, DbCommand command)
        {
            try
            {
                connection.Open();
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        #endregion
    }
}