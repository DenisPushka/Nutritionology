namespace Nutritionology;

/// <summary>
/// Методические рекомендации (МР).
/// Methodological Recommendations (MR).
/// </summary>
public class MR
{
    /// <summary>
    /// PK.
    /// </summary>
    public Guid MRId { get; set; }
    
    /// <summary>
    /// Биологический элемент.
    /// </summary>
    public MRItem MrItem { get; set; }
    
    /// <summary>
    /// Пол.
    /// </summary>
    public Gender Gender { get; set; }
    
    /// <summary>
    /// Данные.
    /// </summary>
    public decimal Data { get; set; }
    
    /// <summary>
    /// Начальный возраст.
    /// </summary>
    public decimal StartAge { get; set; }
    
    /// <summary>
    /// Конечный возраст параметра.
    /// </summary>
    public decimal FinishAge { get; set; }
}