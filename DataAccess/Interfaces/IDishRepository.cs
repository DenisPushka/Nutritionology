using Nutritionology;

namespace DataAccess.Interfaces;

/// <summary>
/// Интерфейс для запросов к таблице "Блюдо" (Dish), рецепт (Recipe) и продукт блюдо Мап.
/// </summary>
public interface IDishRepository
{
    /// <summary>
    /// Добавление блюда.
    /// </summary>
    /// <param name="dish">Добавляемое блюдо.</param>
    /// <returns>Добаленное блюдо.</returns>
    Task<Dish> AddDish(Dish dish);

    /// <summary>
    /// Получение массива блюд.
    /// </summary>
    /// <returns>Массив блюд.</returns>
    Task<Dish[]> GetDishes();

    /// <summary>
    /// Получение блюда по <paramref name="dishId"/>.
    /// </summary>
    /// <param name="dishId">Id блюда.</param>
    /// <returns>Блюдо.</returns>
    Task<Dish> GetDish(Guid dishId);

    /// <summary>
    /// Получение блюда по миени.
    /// </summary>
    /// <param name="name">Название блюда.</param>
    /// <returns>Искомое блюдо.</returns>
    Task<Dish> GetDish(string name);


}