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
    /// </summary>
    public int Weight { get; set; }
    
    /// <summary>
    /// Процент дневной нормы.
    /// </summary>
    // TODO THINK!
    public double DayNorm { get; set; }

    /// <summary>
    /// Продукты.
    /// </summary>
    public ProductDishMap[] Products { get; set; }
    
    /// <summary>
    /// Фото блюда.
    /// </summary>
    public byte[][] Photos { get; set; }
    
    /// <summary>
    /// Рецепт.
    /// </summary>
    public Recipe Recipe { get; set; }
    
    /// <summary>
    /// Прием пищи.
    /// </summary>
    public MealTime[]? MealTime { get; set; }
    
    /// <summary>
    /// Это напиток.
    /// </summary>
    public bool IsDrink { get; set; }
}