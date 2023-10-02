using LinqToDB;
using Microsoft.Extensions.Configuration;
using Nutritionology;
using Validation;

namespace DataAccess.Providers
{
    /// <summary>
    /// Провайдер Linq2db к словарям связанным с таблицей МР, 
    /// те (СИ, Биологические элементы, Элемент МР).
    /// </summary>
    public class MRLinq2Db : ParentSql
    {
        public MRLinq2Db(IConfiguration config)
            : base(config)
        {
        }

        /// <summary>
        /// Получить массив объектов СИ.
        /// </summary>
        /// <returns>Массив объектов СИ.</returns>
        public async Task<MeasurementSystem[]> GetAllMs()
        {
            await using var db = new DbNutritonology(Connection);

            var mses =
                from ms in db.MeasurementSystem
                select ms;

            return mses.ToArray();
        }

        /// <summary>
        /// Получение всех биологических элементов.
        /// </summary>
        /// <returns>Массив всех биологических элементов.</returns>
        public async Task<BiologicalElement[]> GetBiologicallyElements()
        {
            await using var db = new DbNutritonology(Connection);

            var bElements =
                from bEl in db.BiologicalElements
                select bEl;

            return bElements.ToArray();
        }

        /// <summary>
        /// Получение всех элементов МР.
        /// </summary>
        /// <returns>Массив всех элементов МР.</returns>
        public async Task<MRItem[]> GetMrItems()
        {
            await using var db = new DbNutritonology(Connection);

            var mrItems =
                from mr in db.MRItems
                select mr;

            return mrItems
                .LoadWith(request => request.MeasurementSystem)
                .LoadWith(request => request.BiologicalElement)
                .ToArray();
        }

        /// <summary>
        /// Изменение элемента МР.
        /// </summary>
        /// <param name="mrItem">Измененный объект.</param>
        public async Task UpdateMrItem(MRItem mrItem)
        {
            ValidationHelper.CheckObject(mrItem);
            ValidationHelper.CheckString(mrItem.Name);
            ValidationHelper.CheckObject(mrItem.MeasurementSystem);
            ValidationHelper.CheckGuid(mrItem.MeasurementSystem.MSId);
            ValidationHelper.CheckObject(mrItem.BiologicalElement);
            ValidationHelper.CheckGuid(mrItem.BiologicalElement.BiologicalElementId);

            await using var db = new DbNutritonology(Connection);
            await db.MRItems
                .Where(item => item.MRItemId.Equals(mrItem.MRItemId))
                .Set(item => item.Name, mrItem.Name)
                .Set(item => item.MSId, mrItem.MeasurementSystem.MSId)
                .Set(item => item.BiologicalElementId, mrItem.BiologicalElement.BiologicalElementId)
                .UpdateAsync();
        }
    }
}