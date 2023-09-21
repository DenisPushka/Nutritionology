using LinqToDB.Mapping;

namespace Nutritionology;

/// <summary>
/// Система измерений (СИ).
/// Measurement System (MS).
/// </summary>
[Table(Name = "MeasurementSystem")]
public class MeasurementSystem
{
    /// <summary>
    /// PK.
    /// </summary>
    [PrimaryKey]
    public Guid MSId { get; set; }

    /// <summary>
    /// Краткое название.
    /// </summary>
    [Column(Name = "ShortName")]
    public string? ShortName { get; set; }

    /// <summary>
    /// Полное название.
    /// </summary>
    [Column(Name = "FullName")]
    public string? FullName { get; set; }
}