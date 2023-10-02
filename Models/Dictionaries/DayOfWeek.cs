namespace Nutritionology;

/// <summary>
/// День недели.
/// </summary>
public class DayOfWeek
{
    /// <summary>
    /// PK.
    /// </summary>
    public Guid DayOfWeekId { get; set; }
    
    /// <summary>
    /// Короткое название.
    /// </summary>
    public string? ShortName { get; set; }
    
    /// <summary>
    /// Полное название.
    /// </summary>
    public string? FullName { get; set; }
}