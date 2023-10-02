using LinqToDB.Mapping;

namespace Nutritionology;

/// <summary>
/// Название продукта.
/// </summary>
[Table(Name = "ProductName")]
public class ProductName
{
    /// <summary>
    /// PK.
    /// </summary>
    [PrimaryKey]
    public Guid ProductNameId { get; set; }
    
    /// <summary>
    /// Название.
    /// </summary>
    [Column(Name = "Name")]
    public string Name { get; set; }
}