/// <summary>
/// Хранилище запросов для таблицы МР и связанных с ней словарей: 
/// СИ, Элемент МР, Биологический элемент.
/// </summary>
internal static class SqlScriptsMr
{
    #region СИ

    /// <summary>
    /// Добавление объекта СИ.
    /// Запрос не имеет VALUES.
    /// </summary>
    public const string AddMsShot =
        "INSERT INTO [aspnet-Nutritionology].[dbo].[MethodologicalRecommendation]" +
        "   (" +
        "       [ShortName]" +
        "       [FullName]" +
        "   ) " +
        "VALUES ";

    /// <summary>
    /// Добавление объекта СИ.
    /// @shortName - название, пример: кг, г, мл.
    /// @fullName - название, пример: Килограмм, Грамм, Миллилитры.
    /// </summary>
    public const string AddMs =
        AddMsShot +
        "   (" +
        "       @shortName " +
        "       @fullName " +
        "   )";

    #endregion

    #region Биологический элемент

    /// <summary>
    /// Добавление значений в таблицу Биологический элемент.
    /// Запрос не имеет VALUES.
    /// </summary>
    public const string AddBElShot =
        "INSERT INTO [aspnet-Nutritionology].[dbo].[BiologicalElement]" +
        "   (" +
        "       [ShortName]" +
        "       [FullName]" +
        "   ) " +
        "VALUES ";

    /// <summary>
    /// Добавление значений в таблицу Биологический элемент.
    /// @shortName - Короткое название;
    /// @fulltName - Полное название.
    /// </summary>
    public const string AddBEl =
        AddBElShot + "( " +
        "     @shortName " +
        "     , @fullName " +
        ")";

    #endregion

    #region Элемент МР

    /// <summary>
    /// Добавление значений в таблицу Элемент МР.
    /// Запрос не имеет VALUES.
    /// </summary>
    public const string AddMrItemShot =
        "INSERT INTO [aspnet-Nutritionology].[dbo].[MRItem]" +
        "   (" +
        "       [Name]" +
        "       , [MSId]" +
        "       , [BiologicalElementId]" +
        "   ) " +
        "VALUES ";

    /// <summary>
    /// Добавление значений в таблицу Элемент МР.
    /// @name - Название элемента;
    /// @msId - Id значения из таблицы СИ;
    /// @biologicalElementId - Id значения из таблицы Биологический элемент.
    /// </summary>
    public const string AddMrItem =
        AddMrItemShot +
        "   (" +
        "       @name " +
        "       , @msId " +
        "       , @biologicalElementId" +
        "   )";


    /// <summary>
    /// Получение элементов МР.
    /// </summary>
    public const string GetMrItems =
        "USE [aspnet-Nutritionology] " +
        "SELECT TOP (1000) " +
        "    [MRItemId]" +
        "    , MRI.[Name]" +
        "    , BL.[ShortName]" +
        "    , BL.[FullName]" +
        "    , MeasurementSystem.[ShortName]	" +
        "    , MeasurementSystem.[FullName] " +
        "FROM [dbo].[MRItem] MRI " +
        "    INNER JOIN[dbo].[MeasurementSystem] MeasurementSystem " +
        "        ON MeasurementSystem.MSId = MRI.MSId" +
        "    INNER JOIN[dbo].[BiologicalElement] BL" +
        "        ON BL.BiologicalElementId = MRI.BiologicalElementId ";

    #endregion

    #region МР

    /// <summary>
    /// Добавление МР.
    /// Запрос не имеет VALUES.
    /// </summary>
    public const string AddMrShot =
        "INSERT INTO [aspnet-Nutritionology].[dbo].[MethodologicalRecommendation]" +
        "   (" +
        "       [MrItemId]" +
        "       , [GenderId]" +
        "       , [Data]" +
        "       , [StartAge] " +
        "       , [FinishAge] " +
        "   ) " +
        "VALUES ";

    /// <summary>
    /// Добавление МР.
    /// @mrItemId - Id элемента МР;
    /// @genderId - Id пола;
    /// @data - Значение;
    /// @startAge - Начальный возраст;
    /// @finishAge - Конечный возраст;
    /// </summary>
    public const string AddMr =
        AddMrShot +
        "   (" +
        "       @mrItemId " +
        "       , @genderId " +
        "       , @data" +
        "       , @startAge" +
        "       , @finishAge" +
        "   )";

    /// <summary>
    /// Получение всех МР.
    /// </summary>
    public const string GetMrs =
        "USE [aspnet-Nutritionology] " +
        "SELECT TOP(1000)" +
        "    [MRId]" +
        "	 , MRIt.[Name]" +
        "    , MeasurementSystem.[ShortName]" +
        "    , MeasurementSystem.[FullName]" +
        "    , BL.[ShortName]" +
        "    , BL.[FullName]" +
        "    , G.[ShortName]" +
        "    , G.[FullName]" +
        "    , [Data]" +
        "    , [StartAge]" +
        "    , [FinishAge] " +
        "FROM [dbo].[MethodologicalRecommendation] MR" +
        "    INNER JOIN[dbo].[MRItem] MRIt" +
        "        ON MRIt.MRItemId = MR.MrItemId" +
        "    LEFT JOIN[dbo].[Gender] G" +
        "        ON G.GenderId = MR.GenderId" +
        "    INNER JOIN[dbo].[BiologicalElement] BL " +
        "        ON BL.BiologicalElementId = MRIt.BiologicalElementId" +
        "    INNER JOIN[dbo].[MeasurementSystem] MeasurementSystem " +
        "        ON MeasurementSystem.MSId = MRIt.MSId";


    /// <summary>
    /// Обновление значений в объекте МР.
    /// @mrItemId -Id объекта МР;
    /// @genderId - Id пола;
    /// @data - Данные; 
    /// @startAge - Начальный возраст;
    /// @finishAge - Конечный возраст;
    /// @mrId - Id объекта у которого нужно поменять значения.
    /// </summary>
    public const string UpdateMr =
        "UPDATE [aspnet-Nutritionology].[dbo].[MethodologicalRecommendation] " +
        "   SET " +
        "       [MrItemId] = @mrItemId" +
        "       ,[GenderId] = @genderId" +
        "       ,[Data] = @data" +
        "       ,[StartAge] = @startAge" +
        "       ,[FinishAge] = @finishAge " +
        "WHERE [MRId] = @mrId ";

    #endregion
}