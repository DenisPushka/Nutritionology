using System.Diagnostics;
using System.Globalization;
using System.Text;
using DataAccess.Providers;
using DataAccess.SQLScripts;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Nutritionology;
using Validation;

namespace DataAccess;

/// <summary>
/// Реализатор запросов к таблице "Блюдо" (Dish),
/// СИ (MS), рецепт (Recipe) и продукт блюдо Мап.
/// </summary>
public class DishAspNet : ParentSql
{
    public DishAspNet(IConfiguration config)
        : base(config)
    {
    }

    /// <summary>
    /// Добавление блюда.
    /// </summary>
    /// <param name="dish">Добавляемое блюдо.</param>
    /// <returns>Добаленное блюдо.</returns>
    public async Task AddDish(Dish dish)
    {
        ValidationHelper.CheckObject(dish);
        ValidationHelper.CheckObject(dish.Products);
        ValidationHelper.CheckString(dish.Name);

        dish.Weight = await CalculateWeight(dish.Products);

        await using var connection = new SqlConnection(Connection);
        var command = new SqlCommand(SqlScriptsDishes.AddDish, connection);
        
        command.Parameters.AddWithValue("@number", dish.NumberProduct);
        command.Parameters.AddWithValue("@name", dish.Name);
        command.Parameters.AddWithValue("@weight", dish.Weight);
        command.Parameters.AddWithValue("@isDrink", dish.IsDrink); // TODO TEST!
        
        await DoQuery(connection, command);
        
        var dishId = await GetDishGuidForName(dish.Name);
        await AddProductInDish(dish.Products, dishId);
        await AddDishPhotos(dish.Photos, dishId);
        await AddMealTime(dish.MealTime, dishId); 
        await AddRecipe(dish.Recipe, dishId);
    }

    /// <summary>
    /// Высчитывание веса блюда.
    /// </summary>
    /// <param name="productDishMaps">Продукты.</param>
    /// <returns>Высчитываемыый вес.</returns>
    private static Task<int> CalculateWeight(IEnumerable<ProductDishMap> productDishMaps)
    {
        ValidationHelper.CheckObject(productDishMaps);

        foreach (var item in productDishMaps)
        {
            ValidationHelper.CheckObject(item);
            ValidationHelper.CheckObject(item.MS);
            ValidationHelper.CheckString(item.MS.ShortName);
        }

        decimal weight = 0;

        foreach (var product in productDishMaps)
            switch (product.MS.ShortName)
            {
                case "кг" or "л":
                    weight += product.Weight / 1000;
                    continue;
                case "мкг" or "кКал" or "МЕ":
                    continue;
                default:
                    weight += product.Weight;
                    continue;
            }

        return Task.FromResult((int)weight);
    }

    /// <summary>
    /// Добавление продуктов в блюде.
    /// </summary>
    /// <param name="products">Продукты.</param>
    /// <param name="dishId">Блюдо.</param>
    private async Task AddProductInDish(IEnumerable<ProductDishMap> products, Guid dishId)
    {
        ValidationHelper.CheckObject(products);
        ValidationHelper.CheckGuid(dishId);

        foreach (var item in products)
        {
            ValidationHelper.CheckObject(item);
            ValidationHelper.CheckObject(item.Product);
            ValidationHelper.CheckGuid(item.Product.ProductId);
            ValidationHelper.CheckObject(item.MS);
            ValidationHelper.CheckGuid(item.MS.MSId);
        }

        var queryAddMrItems = new StringBuilder(SqlScriptsDishes.AddProducts);

        foreach (var product in products)
        {
            queryAddMrItems
                .Append("(\'")
                .Append(product.Product.ProductId)
                .Append("\', \'")
                .Append(dishId)
                .Append("\', \'")
                .Append(product.MS.MSId)
                .Append("\', ")
                .Append(product.Weight.ToString(CultureInfo.InvariantCulture).Replace(',', '.'))
                .Append("),");
        }

        queryAddMrItems.Remove(queryAddMrItems.Length - 1, 1);

        await AddObjectInDb(queryAddMrItems.ToString());
    }

    // todo не протестировано.
    /// <summary>
    /// Добавление приемов пищи блюду.
    /// </summary>
    /// <param name="mealTimes">Приемы пищи.</param>
    /// <param name="dishId">Id блюда.</param>
    private async Task AddMealTime(IReadOnlyCollection<MealTime>? mealTimes, Guid dishId)
    {
        if (mealTimes == null || mealTimes.Count == 0)
        {
            return;
        }
        
        ValidationHelper.CheckGuid(dishId);
        ValidationHelper.CheckObject(mealTimes);

        foreach (var mealTime in mealTimes)
        {
            ValidationHelper.CheckGuid(mealTime.MealTimeId);
        }
        
        var queryAddMrItems = new StringBuilder(SqlScriptsDishes.AddMealTimeToDish);

        foreach (var mealTime in mealTimes)
        {
            queryAddMrItems
                .Append("(\'")
                .Append(mealTime.MealTimeId)
                .Append("\', \'")
                .Append(dishId)
                .Append("\',),");
        }

        queryAddMrItems.Remove(queryAddMrItems.Length - 1, 1);

        await AddObjectInDb(queryAddMrItems.ToString());
    }
    
    // todo не протестировано.
    /// <summary>
    /// Добавление фоток блюду.
    /// </summary>
    /// <param name="photo">Фото.</param>
    /// <param name="dishId">Id блюда.</param>
    private async Task AddDishPhotos(IReadOnlyCollection<byte[]>? photo, Guid dishId)
    {
        if (photo == null || photo.Count == 0)
        {
            return;
        }
        
        ValidationHelper.CheckGuid(dishId);
        ValidationHelper.CheckObject(photo);

        foreach (var ph in photo)
        {
            ValidationHelper.CheckObject(ph);
        }
        
        var queryAddMrItems = new StringBuilder(SqlScriptsDishes.AddPhotoToDish);

        foreach (var ph in photo)
        {
            queryAddMrItems
                .Append('(')
                .Append(ph)
                .Append(", \'")
                .Append(dishId)
                .Append("\',),");
        }

        queryAddMrItems.Remove(queryAddMrItems.Length - 1, 1);

        await AddObjectInDb(queryAddMrItems.ToString());
    }

    // TODO Not testing.
    /// <summary>
    /// Добавление рецепта.
    /// </summary>
    /// <param name="recipe">Добавляемый рецепт.</param>
    /// <param name="dishId">Id блюда.</param>
    private async Task AddRecipe(Recipe? recipe, Guid dishId)
    {
        if (recipe == null || string.IsNullOrEmpty(recipe.Description))
        {
            return;
        }

        ValidationHelper.CheckString(recipe.Description);
        ValidationHelper.CheckGuid(dishId);
        
        await using var connection = new SqlConnection(Connection);
        var command = new SqlCommand(SqlScriptsDishes.AddRecipe, connection);
        
        command.Parameters.AddWithValue("@description", recipe.Description);
        command.Parameters.AddWithValue("@dishId", dishId);
        command.Parameters.AddWithValue("@isPrivate", recipe.IsPrivate); // todo проверить.
        
        await DoQuery(connection, command);
    }
    
    /// <summary>
    /// Получение Id блюда по его названию.
    /// </summary>
    /// <param name="name">Название блюда.</param>
    /// <returns>Id (guid) блюда.</returns>
    public async Task<Guid> GetDishGuidForName(string name)
    {
        ValidationHelper.CheckString(name);

        await using var connection = new SqlConnection(Connection);
        var command = new SqlCommand(string.Concat(SqlScriptsDishes.GetDishGuidForName, $"\'%{name}%\'")
            , connection);

        try
        {
            await connection.OpenAsync();
            var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return (Guid)reader[0];
            }
        }
        catch (SqlException e)
        {
            Debug.WriteLine(e);
            throw;
        }

        return Guid.Empty;
    }

    /// <summary>
    /// Получение блюда по названию.
    /// </summary>
    /// <param name="name">Название блюда.</param>
    /// <returns>Получаемое блюдо.</returns>
    public async Task<Dish> GetDishForName(string name)
    {
        ValidationHelper.CheckString(name);

        var dish = new Dish();
        var products = new List<ProductDishMap>();

        await using var connection = new SqlConnection(Connection);
        var command = new SqlCommand(string.Concat(SqlScriptsDishes.GetDish, $"\'%{name}%\'")
            , connection);

        try
        {
            await connection.OpenAsync();
            var reader = await command.ExecuteReaderAsync();
            var getDishData = false;

            while (await reader.ReadAsync())
            {
                if (!getDishData)
                {
                    dish.DishId = (Guid)reader[0];
                    dish.Name = (string)reader[1];
                    dish.Weight = (int)reader[2];
                    getDishData = true;
                    dish.Recipe = new Recipe
                    {
                        RecipeId = reader[9] is DBNull
                            ? Guid.Empty
                            : (Guid)reader[9],
                        Description = reader[10] is DBNull
                            ? ""
                            : (string)reader[10],
                        DishId = (Guid)reader[0]
                    };
                }

                products.Add(
                    new ProductDishMap
                    {
                        Product = new Product
                        {
                            ProductId = (Guid)reader[7],
                            FullName = (string)reader[8]
                        },
                        ProductDishMapId = (Guid)reader[3],
                        Weight = (decimal)reader[4],
                        MS = new MeasurementSystem
                        {
                            MSId = reader[5] is DBNull
                                ? Guid.Empty
                                : (Guid)reader[5],
                            ShortName = reader[6] is DBNull
                                ? ""
                                : (string)reader[6],
                        },
                    });
            }
        }
        catch (SqlException e)
        {
            Debug.WriteLine(e);
            throw;
        }

        dish.Products = products.ToArray();
        return dish;
    }
}