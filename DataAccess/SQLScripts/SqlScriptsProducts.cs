namespace DataAccess.SQLScripts;

/// <summary>
/// Хранилище запросов для таблицы "Продуктов",
/// "ПродуктМРЭлементМап", "ПродуктМРЭлементМапБлюдоМап" .
/// </summary>
internal class SqlScriptsProducts
{
    /// <summary>
    /// Добавление информации о продукте.
    /// @productId - Id продукта; 
    /// @mrItemId - id элемента МР;
    /// @foodValue - пищевая ценность;
    /// @chemicalValue - хим. ценность.
    /// </summary>
    public const string AddProductMrItems =
        "INSERT INTO [aspnet-Nutritionology].[dbo].[ProductMRItemMap]" +
        "   (" +
        "       [ProductId]" +
        "       ,[MRItemId]" +
        "       ,[FoodValue]" +
        "       ,[ChemicalValue]" +
        "   ) " +
        "VALUES ";
    
    /// <summary>
    /// Добавление продукта.
    /// @productNameId - Id названия продукта; 
    /// @fullName - полное название продукта. 
    /// </summary>
    public const string AddProduct =
        "INSERT INTO [aspnet-Nutritionology].[dbo].[Product]" +
        "   (" +
        "       [ProductNameId]" +
        "       , [FullName]" +
        "   ) " +
        "VALUES " +
        "   (" +
        "       @productNameId" +
        "       , @fullName" +
        "   )";

    /// <summary>
    /// Получение продуктов.
    /// </summary>
    public const string GetProducts =
        "SELECT P.ProductId" +
        "   , P.FullName" +
        "   , PN.ProductNameId" +
        "   , PN.Name" +
        "   , PMEM.MRItemId " +
        "   , PMEM.FoodValue" +
        "   , PMEM.ChemicalValue " +
        "FROM [aspnet-Nutritionology].[dbo].[Product] P" +
        "   INNER JOIN ProductMRItemMap PMEM" +
        "       ON P.ProductId = PMEM.ProductId" +
        "   INNER JOIN ProductName PN" +
        "       ON P.ProductNameId = PN.ProductNameId";

    /// <summary>
    /// Получение имени продукта по его названию.
    /// </summary>
    public const string GetProductNameForName = 
        "SELECT [ProductNameId], [Name] " +
        "FROM [aspnet-Nutritionology].dbo.ProductName " +
        "WHERE Name = @name";
    
    /// <summary>
    /// Получение продукта по его названию.
    /// </summary>
    public const string GetProductForName = 
        "SELECT P.[ProductId], P.[FullName], PN.[ProductNameId], PN.[Name] " +
        "FROM [aspnet-Nutritionology].dbo.Product P " +
        "   INNER JOIN ProductName PN" +
        "       ON P.ProductNameId = PN.ProductNameId " +
        "WHERE FullName = @fullName";
}