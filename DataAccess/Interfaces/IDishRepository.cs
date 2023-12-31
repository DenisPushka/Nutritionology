﻿using Nutritionology;

namespace DataAccess.Interfaces;

/// <summary>
/// Интерфейс для запросов к таблице "Блюдо" и рецепт (Recipe).
/// </summary>
public interface IDishRepository
{
    /// <summary>
    /// Добавление блюда.
    /// </summary>
    /// <param name="dish">Добавляемое блюдо.</param>
    /// <returns>Массив блюд.</returns>
    Task<Dish[]> AddDish(Dish dish);

    /// <summary>
    /// Получение массива блюд.
    /// </summary>
    /// <returns></returns>
    Task<Dish[]> GetDishes();

    /// <summary>
    /// Получение блюда по <paramref name="dishId"/>.
    /// </summary>
    /// <param name="dishId">Id блюда.</param>
    /// <returns>Блюдо.</returns>
    Task<Dish> GetDish(Guid dishId);
    
    
}