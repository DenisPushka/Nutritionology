namespace Nutritionology;

/// <summary>
/// Промежуточная таблица для хранения продуктов в блюде.
/// </summary>
public class ProductDishMap
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid ProductDishMapId { get; set; }
    
    /// <summary>
    /// Id блюда.
    /// </summary>
    public Guid DishId { get; set; }

    /// <summary>
    /// Id продукта.
    /// </summary>
    public Guid ProductId { get; set; }
    
    /// <summary>
    /// Продукт.
    /// </summary>
    public Product Product { get; set; }
    
    /// <summary>
    /// Вес.
    /// </summary>
    public decimal Weight { get; set; }
    
    /// <summary>
    /// Id к таблицу СИ.
    /// </summary>
    public Guid MSId { get; set; }
    
    /// <summary>
    /// Объект СИ.
    /// </summary>
    public MeasurementSystem MS { get; set; }
}