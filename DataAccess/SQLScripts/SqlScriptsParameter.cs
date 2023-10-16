namespace DataAccess.SQLScripts;

/// <summary>
/// Хранилище запросов для таблицы "Параметр" и прилегающих к ней
/// словарей "Вкусовые предпочтения" и "Проблемные продукты".
/// </summary>
public static class SqlScriptsParameter
{
    /// <summary>
    /// Добавление параметра.
    /// </summary>
    public const string AddParameter = 
        "INSERT INTO Parameter" + 
        "   (ParameterId, GenderId, Weight, Height, Age) " +
        "VALUES " + 
        "   (" + 
        "       @parameterId" +
        "       , @genderId" + 
        "       , @weight" + 
        "       , @height" + 
        "       , @age" + 
        "   )";

    /// <summary>
    /// Добавление связи между пользвоателем и параметром.
    /// </summary>
    public const string AddDeferenceParameterUser =
        "INSERT INTO UserParameterMap " +
        "   (UserId, ParameterId) " +
        "VALUES" +
        "   (" +
        "       @userId" +
        "       , @parameterId  " +
        "   )";

    /// <summary>
    /// Добавление любимых продуктов.
    /// </summary>
    public const string AddLikeProducts =
        "INSERT INTO LikeProduct" +
        "   (ParameterId, ProductId) " +
        "VALUES ";
    
    
    /// <summary>
    /// Добавление проблемных продуктов.
    /// </summary>
    public const string AddProblemProducts =
        "INSERT INTO ProblemProduct" +
        "   (ParameterId, ProductId) " +
        "VALUES ";
}