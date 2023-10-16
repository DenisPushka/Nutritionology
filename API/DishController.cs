using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Nutritionology;

namespace API;

/// <summary>
/// Контроллер для взаимодействия с Таблицей "Блюдо".
/// </summary>
[ApiController, Route("[controller]")]
public class DishController : ControllerBase
{
    /// <summary>
    /// Репозиторий блюда и всех "Блюдо" (Dish), рецепт (Recipe), СИ (MS) и продукт блюдо Мап.
    /// </summary>
    private readonly IDishRepository _dishRepository;

    public DishController(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    /// <summary>
    /// Добавление блюда.
    /// </summary>
    /// <param name="dish">Добавляемое блюдо.</param>
    /// <returns>Добаленное блюдо.</returns>
    [HttpPost, Route("AddDish")]
    public async Task<IActionResult> AddDish(Dish dish) => Ok(await _dishRepository.AddDish(dish));

    /// <summary>
    /// Получение массива блюд.
    /// </summary>
    /// <returns>Массив блюд.</returns>
    [HttpGet, Route("GetDishes")]
    public async Task<IActionResult> GetDishes() => Ok(await _dishRepository.GetDishes());

    /// <summary>
    /// Получение блюда по имени.
    /// </summary>
    /// <param name="name"></param>
    /// <returns>Искомое блюдо.</returns>
    [HttpGet, Route("GetDish")]
    public async Task<IActionResult> GetDish(string name) => Ok(await _dishRepository.GetDish(name));
}