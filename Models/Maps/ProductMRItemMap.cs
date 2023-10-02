using LinqToDB.Mapping;

namespace Nutritionology;

/// <summary>
/// Таблица N : N - Продукт : Элемент МР. 
/// </summary>
[Table(Name = "ProductMRItemMap")]
public class ProductMRItemMap
{
    /// <summary>
    /// PK.
    /// </summary>
    [PrimaryKey]
    public Guid ProductMRItemMapId { get; set; }
    
    /// <summary>
    /// Продукт Id.
    /// </summary>
    [Column(Name = "ProductId")]
    public Guid ProductId { get; set; }
    
    /// <summary>
    /// Продукт.ы
    /// </summary>
    [Association(ThisKey = "ProductId", OtherKey = "ProductId")]
    public Product Product { get; set; }
    
    /// <summary>
    /// Элемент МР Id.
    /// </summary>
    [Column(Name = "MrItemId")]
    public Guid MrItemId { get; set; }
    
    /// <summary>
    /// Элемент МР.
    /// </summary>
    [Association(ThisKey = "MrItemId", OtherKey = "MrItemId")]
    public MRItem MrItem { get; set; }
    
    /// <summary>
    /// Информация. Пищевая ценность.
    /// </summary>
    [Column(Name = "FoodValue")]
    public decimal FoodValue { get; set; }
    
    /// <summary>
    /// Химическая ценность.
    /// </summary>
    [Column(Name = "ChemicalValue")]
    public decimal ChemicalValue { get; set; }
}