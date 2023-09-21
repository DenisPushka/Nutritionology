using LinqToDB.Mapping;

namespace Nutritionology;

/// <summary>
/// Элемент методических рекомендаций. 
/// </summary>
[Table(Name = "MRItem")]
public class MRItem
{
    /// <summary>
    /// PK.
    /// </summary>
    [PrimaryKey]
    public Guid MRItemId { get; set; }

    /// <summary>
    /// Вторичный ключ к таблице СИ.
    /// При запросе этот ключ прокидывать в объект, те в "MeasurementSystem".
    /// </summary>
    [Column(Name = "MSId")]
    public Guid MSId { get; set; }

    /// <summary>
    /// СИ.
    /// </summary>
    [Association(ThisKey = "MSId", OtherKey = "MSId", CanBeNull = false)]
    public MeasurementSystem MeasurementSystem { get; set; }

    /// <summary>
    /// Название элемента.
    /// </summary>
    [Column(Name = "Name")]
    public string Name { get; set; }

    /// <summary>
    /// Вторичный ключ к таблице Биологический элемент.
    /// При запросе этот ключ прокидывать в объект, те в "BiologicalElement".
    /// </summary>
    [Column(Name = "BiologicalElementId")]
    public Guid BiologicalElementId { get; set; }

    /// <summary>
    /// Биологический элемент.
    /// </summary>
    [Association(ThisKey = "BiologicalElementId", OtherKey = "BiologicalElementId", CanBeNull = false)]
    public BiologicalElement BiologicalElement { get; set; }
}