using Nutritionology;
using DayOfWeek = Nutritionology.DayOfWeek;

namespace DataAccess.Interfaces;

/// <summary>
/// Интерфейс для запросов к таблице "Меню".
/// Включает запросы для таблиц: Прием пищи (MealTime), День недели (DayOfWeek). 
/// </summary>
public interface IMenuRepository
{
    /// <summary>
    /// Добавление меню.
    /// </summary>
    /// <param name="menu">Добавление меню.</param>
    /// <returns>Все меню (массив).</returns>
    Task<Menu[]> AddMenu(Menu menu);

    /// <summary>
    /// Добавление меню пользователю.
    /// </summary>
    /// <param name="user">Пользователь, которому добавляют меню.</param>
    /// <param name="menu">Добавляемое меню (НОВОЕ).</param>
    /// <returns>Добавленное меню.</returns>
    Task<Menu> AddMenu(User user, Menu menu);

    /// <summary>
    /// Добавление "Приема пищи".
    /// </summary>
    /// <param name="mealTime">Добавляемый прием пищи.</param>
    /// <returns>Массив приемов пищ.</returns>
    Task<MealTime[]> AddMealTime(MealTime mealTime);

    /// <summary>
    /// Получение всех "Приемов пищи".
    /// </summary>
    /// <returns>Массив приемов пищи.</returns>
    Task<MealTime[]> GetMealTimes();

    /// <summary>
    /// Добавление "Дня недели".
    /// </summary>
    /// <returns>Все дни недели.</returns>
    Task<DayOfWeek[]> AddDayOfWeek();

    /// <summary>
    /// Получение всех дней недели.
    /// </summary>
    /// <returns>Массив всех дней недель.</returns>
    Task<DayOfWeek[]> GetDaysOfWeek();
}