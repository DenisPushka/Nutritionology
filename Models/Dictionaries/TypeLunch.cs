namespace Nutritionology;

/// <summary>
/// Тип обеда.
/// </summary>
public class TypeLunch
{
    /// <summary>
    /// Id. 
    /// </summary>
    public Guid TypeLunchId { get; set; }
    
    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; }
}