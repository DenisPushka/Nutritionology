using Nutritionology;

namespace DataAccess.Interface
{
    /// <summary>
    /// Интерфейс для запросов к таблице "Методические рекомендации".
    /// Включает запросы для МР, элемент МР, СИ и биологического элемента. 
    /// </summary>
    public interface IMRRepository
    {
        #region Система измерений (СИ)

        /// <summary>
        /// Добавление объекта СИ.
        /// </summary>
        /// <param name="ms">Добавляемый объект.</param>
        /// <returns>Массив всех объектов СИ.</returns>
        Task<MeasurementSystem[]> AddMs(MeasurementSystem ms);

        /// <summary>
        /// Добавление массива СИ.
        /// </summary>
        /// <param name="mses">Добавляемый объект.</param>
        /// <returns>Массив всех объектов СИ.</returns>
        Task<MeasurementSystem[]> AddArrayMs(IEnumerable<MeasurementSystem> mses);

        /// <summary>
        /// Получение всех единиц измерений.
        /// </summary>
        /// <returns>Массив всех объектов СИ.</returns>
        Task<MeasurementSystem[]> GetAllMs();

        #endregion

        #region Биологический элемент

        /// <summary>
        /// Добавление биологического элемента.
        /// </summary>
        /// <param name="biologicallyElement">Добавляемый объект.</param>
        /// <returns>Массив всех биологических элементов.</returns>
        Task<BiologicalElement[]> AddBiologicallyElement(BiologicalElement biologicallyElement);

        /// <summary>
        /// Добавление массива биологических элементов.
        /// </summary>
        /// <param name="biologicallyElements">Добавляемый объект.</param>
        /// <returns>Массив всех биологических элементов.</returns>
        Task<BiologicalElement[]> AddBiologicallyElements(IEnumerable<BiologicalElement> biologicallyElements);

        /// <summary>
        /// Получение всех биологических элементов.
        /// </summary>
        /// <returns>Массив всех биологических элементов.</returns>
        Task<BiologicalElement[]> GetBiologicallyElements();

        #endregion

        #region Элемент методических рекомендаций

        /// <summary>
        /// Добавление элемента МР.
        /// </summary>
        /// <param name="mrItem">Добавляемый объект.</param>
        /// <returns>Массив всех элементов МР.</returns>
        Task<MRItem[]> AddMrItem(MRItem mrItem);

        /// <summary>
        /// Добавление массива элементов МР.
        /// </summary>
        /// <param name="mrItems">Добавляемый объект.</param>
        /// <returns>Массив всех элементов МР.</returns>
        Task<MRItem[]> AddMrItems(IEnumerable<MRItem> mrItems);

        /// <summary>
        /// Изменение элемента МР.
        /// </summary>
        /// <param name="mrItem">Измененный объект.</param>
        /// <returns>Массив всех элементов МР.</returns>
        Task<MRItem[]> UpdateMrItem(MRItem mrItem);
        
        /// <summary>
        /// Получение всех элементов МР.
        /// </summary>
        /// <returns>Массив всех элементов МР.</returns>
        Task<MRItem[]> GetMrItems();

        #endregion

        #region Методические рекомендации (МР)

        /// <summary>
        /// Добавление МР.
        /// </summary>
        /// <param name="mr">Добавляемая МР.</param>
        /// <returns>Массив всех МР.</returns>
        Task<MR[]> AddMr(MR mr);

        /// <summary>
        /// Добавление массива МР.
        /// </summary>
        /// <param name="mrs">Добавляемый объект.</param>
        /// <returns>Массив всех МР.</returns>
        Task<MR[]> AddMrs(IEnumerable<MR> mrs);

        /// <summary>
        /// Изменение МР.
        /// </summary>
        /// <param name="mr">Измененный объект.</param>
        /// <returns>Массив всех МР.</returns>
        Task<MR[]> UpdateMr(MR mr);

        /// <summary>
        /// Получение всех МР.
        /// </summary>
        /// <returns>Массив всех МР.</returns>
        Task<MR[]> GetMrs();

        #endregion

        // TODO:
        // Add filter for BL;
        // Add filter name BL.
    }
}
