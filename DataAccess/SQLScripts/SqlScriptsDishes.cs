namespace DataAccess.SQLScripts;

/// <summary>
/// Хранилище запросов для запросов к таблице "Блюдо" (Dish),
/// СИ (MS), рецепт (Recipe) и продукт блюдо Мап.
/// </summary>
internal static class SqlScriptsDishes
{
    /// <summary>
    /// Добавление блюда.
    /// </summary>
    public const string AddDish =
        "INSERT INTO [aspnet-Nutritionology].[dbo].[Dish]" +
        "   ( " +
        "       Number" +
        "       , Name" +
        "       , Weight" +
        "       , IsDrink" +
        "   ) " +
        "VALUES" +
        "   (" +
        "       @number" +
        "       , @name" +
        "       , @weight" +
        "       , @isDrink" +
        "   )";

    /// <summary>
    /// Добавление продуктов через таблицу ProductDishMap.
    /// </summary>
    public const string AddProducts =
        "INSERT INTO [dbo].[ProductDishMap]" +
        "   (" +
        "       [ProductId]" +
        "       , [DishId]" +
        "       , [MSId]" +
        "       , [Weight]" +
        "   ) " +
        "VALUES ";

    /// <summary>
    /// Получение блюда с продуктами.
    /// </summary>
    public const string GetDish =
        "SELECT D.DishId," +
        "   D.Name," +
        "   D.Weight," +
        "   PDM.ProductDishMapId," +
        "   PDM.Weight," +
        "   MS.MSId," +
        "   MS.ShortName," +
        "   P.ProductId," +
        "   P.FullName, " +
        "   R2.RecipeId," +
        "   R2.Description " +
        "FROM [aspnet-Nutritionology].[dbo].[Dish] D" +
        "   LEFT JOIN ProductDishMap PDM " +
        "       ON D.DishId = PDM.DishId" +
        "   LEFT JOIN Product P " +
        "       ON PDM.ProductId = P.ProductId" +
        "   LEFT JOIN MeasurementSystem MS " +
        "       ON PDM.MSId = MS.MSId" +
        "   INNER JOIN Recipe R2 " +
        "       ON D.DishId = R2.DishId " +
        "WHERE R2.IsPrivate = 0 AND D.Name LIKE ";

    // TODO продумать как лучше построить запрос с приемом пищи.
    // "   MT.MealTimeId," +
    // "   MT.Name " +
    // "   LEFT JOIN DishMealTimeMap DMTM " +
    // "      ON D.DishId = DMTM.DishId" +
    // "   LEFT JOIN MealTime MT " +
    // "       ON DMTM.MealTimeId = MT.MealTimeId " +

    /// <summary>
    /// Получение Guid блюда по его названию.
    /// </summary>
    public const string GetDishGuidForName =
        "SELECT DishId " +
        "FROM [aspnet-Nutritionology].[dbo].[Dish] " +
        "WHERE Name LIKE ";

    /// <summary>
    /// Добавление приемов пищи блюду.
    /// </summary>
    public const string AddMealTimeToDish =
        "INSERT INTO [aspnet-Nutritionology].[dbo].[DishMealTimeMap] " +
        "   (" +
        "       [MealTimeId]" +
        "       , [DishId]" +
        "   ) " +
        "VALUES ";
    
    /// <summary>
    /// Добавление фоток блюду.
    /// </summary>
    public const string AddPhotoToDish =
        "INSERT INTO [aspnet-Nutritionology].[dbo].[PhotoDish] " +
        "   (" +
        "       [Photo]" +
        "       , [DishId]" +
        "   ) " +
        "VALUES ";

    /// <summary>
    /// Добавление рецепта.
    /// </summary>
    public const string AddRecipe =
        "INSERT INTO [aspnet-Nutritionology].[dbo].[Recipe] " +
        "   (" +
        "       [Desscription]" +
        "       , [DishId]" +
        "       , [IsPrivate]" +
        "   ) " +
        "VALUES " +
        "   (" +
        "       @description" +
        "       , @dishId" +
        "       , @isPrivate" +
        "   )";
}