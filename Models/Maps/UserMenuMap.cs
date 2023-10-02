namespace Nutritionology;

/// <summary>
/// Таблица N:N - Пользователь : Меню.
/// </summary>
public class UserMenuMap
{
    /// <summary>
    /// Pk.
    /// </summary>
    public Guid UserMenuMapId { get; set; } 
    
    /// <summary>
    /// Id Пользователь.
    /// </summary>
    public Guid UserId { get; set; } 
    
    /// <summary>
    /// Id Меню.
    /// </summary>
    public Guid MenuId { get; set; } 
}