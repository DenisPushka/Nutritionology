using DataAccess.Interfaces;
using DataAccess.Providers;
using Nutritionology;

namespace DataAccess.Repositories;

/// <summary>
/// Репозиторий, реализующий логику для запросов к таблице "Методические рекомендации".
/// </summary>
public class MRRepository : IMRRepository
{
    /// <summary>
    /// Исполнитель запросов asp net для МР.
    /// </summary>
    private readonly MRAspNet _aspNetMr;

    /// <summary>
    /// Исполнитель запросов linq2db для МР.
    /// </summary>
    private readonly MRLinq2Db _linq2DbMr;


    /// <summary>
    /// Конструктор с 2 параметрами.
    /// </summary>
    /// <param name="aspNetMr">Провайдер asp net.</param>
    /// <param name="liq2Db">Провайдер linq2db.</param>
    public MRRepository(MRAspNet aspNetMr, MRLinq2Db liq2Db)
    {
        _aspNetMr = aspNetMr;
        _linq2DbMr = liq2Db;
    }

    #region Add

    /// <summary>
    /// Добавление массива СИ.
    /// </summary>
    /// <param name="mses">Добавляемый объект.</param>
    /// <returns>Массив всех объектов СИ.</returns>
    public async Task<MeasurementSystem[]> AddArrayMs(IEnumerable<MeasurementSystem> mses)
    {
        await _aspNetMr.AddArrayMs(mses);
        return await _linq2DbMr.GetAllMs();
    }

    /// <summary>
    /// Добавление биологического элемента.
    /// </summary>
    /// <param name="biologicallyElement">Добавляемый объект.</param>
    /// <returns>Массив всех биологических элементов.</returns>
    public async Task<BiologicalElement[]> AddBiologicallyElement(BiologicalElement biologicallyElement)
    {
        await _aspNetMr.AddBiologicallyElement(biologicallyElement);
        return await _linq2DbMr.GetBiologicallyElements();
    }

    /// <summary>
    /// Добавление массива биологических элементов.
    /// </summary>
    /// <param name="biologicallyElements">Добавляемый объект.</param>
    /// <returns>Массив всех биологических элементов.</returns>
    public async Task<BiologicalElement[]> AddBiologicallyElements(IEnumerable<BiologicalElement> biologicallyElements)
    {
        await _aspNetMr.AddBiologicallyElements(biologicallyElements);
        return await _linq2DbMr.GetBiologicallyElements();
    }

    /// <summary>
    /// Добавление МР.
    /// </summary>
    /// <param name="mr">Добавляемая МР.</param>
    /// <returns>Массив всех МР.</returns>
    public async Task<MR[]> AddMr(MR mr)
    {
        await _aspNetMr.AddMr(mr);
        return await _aspNetMr.GetMrs();
    }

    /// <summary>
    /// Добавление элемента МР.
    /// </summary>
    /// <param name="mrItem">Добавляемый объект.</param>
    /// <returns>Массив всех элементов МР.</returns>
    public async Task<MRItem[]> AddMrItem(MRItem mrItem)
    {
        await _aspNetMr.AddMrItem(mrItem);
        return await _linq2DbMr.GetMrItems();
    }

    /// <summary>
    /// Добавление массива элементов МР.
    /// </summary>
    /// <param name="mrItems">Добавляемый объект.</param>
    /// <returns>Массив всех элементов МР.</returns>
    public async Task<MRItem[]> AddMrItems(IEnumerable<MRItem> mrItems)
    {
        await _aspNetMr.AddMrItems(mrItems);
        return await _linq2DbMr.GetMrItems();
    }

    /// <summary>
    /// Добавление массива МР.
    /// </summary>
    /// <param name="mrs">Добавляемый объект.</param>
    /// <returns>Массив всех МР.</returns>
    public async Task<MR[]> AddMrs(IEnumerable<MR> mrs)
    {
        await _aspNetMr.AddMrs(mrs);
        return await _aspNetMr.GetMrs();
    }

    /// <summary>
    /// Получение всех единиц измерений.
    /// </summary>
    /// <returns>Массив всех объектов СИ.</returns>
    public async Task<MeasurementSystem[]> AddMs(MeasurementSystem ms)
    {
        await _aspNetMr.AddMs(ms);
        return await _linq2DbMr.GetAllMs();
    }

    #endregion

    #region Get

    /// <summary>
    /// Получение всех единиц измерений.
    /// </summary>
    /// <returns>Массив всех объектов СИ.</returns>
    public async Task<MeasurementSystem[]> GetAllMs() => await _linq2DbMr.GetAllMs();

    /// <summary>
    /// Получение всех биологических элементов.
    /// </summary>
    /// <returns>Массив всех биологических элементов.</returns>
    public async Task<BiologicalElement[]> GetBiologicallyElements() => await _linq2DbMr.GetBiologicallyElements();

    /// <summary>
    /// Получение всех элементов МР.
    /// </summary>
    /// <returns>Массив всех элементов МР.</returns>
    public async Task<MRItem[]> GetMrItems() => await _linq2DbMr.GetMrItems();

    /// <summary>
    /// Получение всех МР.
    /// </summary>
    /// <returns>Массив всех МР.</returns>
    public async Task<MR[]> GetMrs() => await _aspNetMr.GetMrs();

    #endregion

    #region Update

    /// <summary>
    /// Изменение МР.
    /// </summary>
    /// <param name="mr">Измененный объект.</param>
    /// <returns>Массив всех МР.</returns>
    public async Task<MR[]> UpdateMr(MR mr)
    {
        await _aspNetMr.UpdateMr(mr);
        return await _aspNetMr.GetMrs();
    }

    /// <summary>
    /// Изменение элемента МР.
    /// </summary>
    /// <param name="mrItem">Измененный объект.</param>
    /// <returns>Массив всех элементов МР.</returns>
    public async Task<MRItem[]> UpdateMrItem(MRItem mrItem)
    {
        await _linq2DbMr.UpdateMrItem(mrItem);
        return await _linq2DbMr.GetMrItems();
    }

    #endregion
}