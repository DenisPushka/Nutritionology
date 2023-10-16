namespace Nutritionology;

/// <summary>
/// Физ. лицо.
/// </summary>
public class Customer
{
    /// <summary>
    /// Id пользователя.
    /// </summary>
    public Guid CustomerId { get; set; }
    
    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Фамилия.
    /// </summary>
    public string LastName { get; set; }
}