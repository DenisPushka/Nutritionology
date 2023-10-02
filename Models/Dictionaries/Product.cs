using LinqToDB.Mapping;

namespace Nutritionology;

/// <summary>
/// Продукт.
/// </summary>
[Table(Name = "Product")]
public class Product
{
    /// <summary>
    /// PK.
    /// </summary>
    [PrimaryKey]
    public Guid ProductId { get; set; }
    
    /// <summary>
    /// FK к таблице Имен.
    /// </summary>
    [Column(Name = "ProductNameId")]
    public Guid ProductNameId { get; set; }
    
    /// <summary>
    /// Название продукта.
    /// </summary>
    [Association(ThisKey = "ProductNameId", OtherKey = "ProductNameId", CanBeNull = false)]
    public ProductName ProductName { get; set; }
    
    /// <summary>
    /// Полное название продукта.
    /// </summary>
    [Column(Name = "FullName")]
    public string FullName { get; set; }
}