namespace Nutritionology;

/// <summary>
/// Прием пищи.
/// </summary>
public class MealTime
{
    /// <summary>
    /// PK.
    /// </summary>
    public Guid MealTimeId { get; set; }
    
    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; } 
}