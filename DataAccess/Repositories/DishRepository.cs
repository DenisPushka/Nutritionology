using DataAccess.Interfaces;
using Nutritionology;

namespace DataAccess.Repositories;

/// <summary>
/// Репозиторий для запросов к таблице "Блюдо" (Dish), СИ (MS), рецепт (Recipe) и продукт блюдо Мап.
/// </summary>
public class DishRepository : IDishRepository
{
    /// <summary>
    /// Исполнитель запросов asp net для Блюда.
    /// </summary>
    private readonly DishAspNet _aspNetDish;

    public DishRepository(DishAspNet aspNetDish)
    {
        _aspNetDish = aspNetDish;
    }

    /// <summary>
    /// Добавление блюда.
    /// </summary>
    /// <param name="dish">Добавляемое блюдо.</param>
    /// <returns>Добаленное блюдо.</returns>
    public async Task<Dish> AddDish(Dish dish)
    {
        await _aspNetDish.AddDish(dish);

        return await GetDish(dish.Name);
    }

    /// <summary>
    /// Получение массива блюд.
    /// </summary>
    /// <returns>Массив блюд.</returns>
    public Task<Dish[]> GetDishes()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Получение блюда по <paramref name="dishId"/>.
    /// </summary>
    /// <param name="dishId">Id блюда.</param>
    /// <returns>Блюдо.</returns>
    public Task<Dish> GetDish(Guid dishId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Получение блюда по миени.
    /// </summary>
    /// <param name="name">Название блюда.</param>
    /// <returns>Искомое блюдо.</returns>
    public async Task<Dish> GetDish(string name) => await _aspNetDish.GetDishForName(name);
}