using LinqToDB.Mapping;

namespace Nutritionology;

/// <summary>
/// Биологический элемент.
/// </summary>
[Table(Name = "BiologicalElement")]
public class BiologicalElement
{
    /// <summary>
    /// PK.
    /// </summary>
    [PrimaryKey]
    public Guid BiologicalElementId { get; set; }

    /// <summary>
    /// Короткое название.
    /// </summary>
    [Column(Name = "ShortName")]
    public string? ShortName { get; set; }

    /// <summary>
    /// Полное название.
    /// </summary>
    [Column(Name = "FullName")]
    public string? FullName { get; set; }
}