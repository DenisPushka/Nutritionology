using LinqToDB.Mapping;

namespace Nutritionology;

/// <summary>
/// Меню.
/// </summary>
[Table(Name = "Menu")]
public class Menu
{
    /// <summary>
    /// PK.
    /// </summary>
    [PrimaryKey]
    public Guid MenuId { get; set; }
    
    // /// <summary>
    // /// Прием пищи FK.
    // /// </summary>
    // [Column(Name = "MealTimeId")]
    // public Guid MealTimeId { get; set; }
    //
    // /// <summary>
    // /// Прием пищи.
    // /// </summary>
    // [Association(ThisKey = "MealTimeId", OtherKey = "MealTimeId")]
    // public MealTime MealTime { get; set; }
    
    /// <summary>
    /// День недели FK.
    /// </summary>
    [Column(Name = "DayOfWeekId")]
    public Guid DayOfWeekId { get; set; }
    
    /// <summary>
    /// День недели.
    /// </summary>
    [Association(ThisKey = "DayOfWeekId", OtherKey = "DayOfWeekId")]
    public DayOfWeek DayOfWeek { get; set; }
    
    /// <summary>
    /// Номер приема пищи.
    /// </summary>
    [Column(Name = "NumberMealTime")]
    public int NumberMealTime { get; set; }
    
    /// <summary>
    /// Номер недели.
    /// </summary>
    [Column(Name = "NumberDayOfWeek")]
    public int NumberDayOfWeek { get; set; }
}