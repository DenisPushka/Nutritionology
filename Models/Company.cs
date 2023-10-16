namespace Nutritionology;

/// <summary>
/// Компания, юр лицо.
/// </summary>
public class Company
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid CompanyId { get; set; }
    
    /// <summary>
    /// Название компании.
    /// </summary>
    public string Name { get; set; } 
}