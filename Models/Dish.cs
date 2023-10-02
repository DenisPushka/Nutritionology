namespace Nutritionology;

/// <summary>
/// Блюдо.
/// </summary>
public class Dish
{
    /// <summary>
    /// PK.
    /// </summary>
    public Guid DishId { get; set; }

    /// <summary>
    /// Номер продукта.
    /// </summary>
    /// TODO NEED?
    public int NumberProduct { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Вес.
    /// TODO VALIDATION + ВЫНЕСТИ, ЕСЛИ В ПАРАМЕТРЕ ВСЕ БУДЕТ ХОРОШО.
    /// </summary>
    public int Weight { get; set; }
    
    /// <summary>
    /// Процент дневной нормы.
    /// </summary>
    public double DayNorm { get; set; }
    
    /// <summary>
    /// Рецепт приготовления.
    /// </summary>
    public string CookRecipe { get; set; }
    
    /// <summary>
    /// Продукты.
    /// </summary>
    public List<ProductMRItemMap> Products { get; set; }
    
    /// <summary>
    /// Фото блюда.
    /// </summary>
    public List<byte[]> Photos { get; set; }
    
    /// <summary>
    /// Рецепт.
    /// </summary>
    public Recipe Recipe { get; set; }
    
    /// <summary>
    /// Прием пищи FK.
    /// </summary>
    public Guid MealTimeId { get; set; }
    
    /// <summary>
    /// Прием пищи.
    /// </summary>
    public MealTime MealTime { get; set; }
}