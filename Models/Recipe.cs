namespace Nutritionology;

/// <summary>
/// Рецепт.
/// </summary>
public class Recipe
{
    /// <summary>
    /// PK.
    /// </summary>
    public Guid RecipeId { get; set; }
    
    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Id блюда.
    /// </summary>
    public Guid DishId { get; set; }
    
    /// <summary>
    /// Засекречн ли рецепт.
    /// </summary>
    public bool IsPrivate { get; set; }
}