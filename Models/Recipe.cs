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
    
    public Guid DishId { get; set; }
}