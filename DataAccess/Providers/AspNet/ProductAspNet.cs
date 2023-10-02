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
/// Реализатор запросов для таблицы "Продукт" и прилегающих к ней
/// словарей (Элемент МР, СИ, Биологический элемент).
/// </summary>
public class ProductAspNet : ParentSql
{
    public ProductAspNet(IConfiguration config)
        : base(config)
    {
    }

    /// <summary>
    /// Добавление информации о продукте.
    /// </summary>
    /// <param name="productMrItems">Добавляемая информация в виде массива.</param>
    public async Task AddProductMrItems(ProductMRItemMap[] productMrItems)
    {
        ValidationHelper.CheckObject(productMrItems);
        ValidationHelper.CheckGuid(productMrItems[0].Product.ProductId);

        foreach (var item in productMrItems)
        {
            ValidationHelper.CheckObject(item);
            ValidationHelper.CheckObject(item.MrItem);
            ValidationHelper.CheckGuid(item.MrItem.MRItemId);
            ValidationHelper.CheckObject(item.Product);
        }

        var queryAddMrItems = new StringBuilder(SqlScriptsProducts.AddProductMrItems);

        var prDefault = productMrItems[0].Product;
        foreach (var it in productMrItems)
        {
            queryAddMrItems
                .Append("(\'")
                .Append(prDefault.ProductId)
                .Append("\', \'")
                .Append(it.MrItem.MRItemId)
                .Append("\', ")
                .Append(it.FoodValue.ToString(CultureInfo.InvariantCulture).Replace(',', '.'))
                .Append(", ")
                .Append(it.ChemicalValue)
                .Append("),");
        }

        queryAddMrItems.Remove(queryAddMrItems.Length - 1, 1);

        await AddObjectInDb(queryAddMrItems.ToString());
    }

    /// <summary>
    /// Добавление продукта.
    /// </summary>
    /// <param name="product">Добавляемый пролукт.</param>
    public async Task AddProduct(Product product)
    {
        ValidationHelper.CheckObject(product);
        ValidationHelper.CheckObject(product.ProductName);
        ValidationHelper.CheckGuid(product.ProductName.ProductNameId);
        ValidationHelper.CheckString(product.FullName);

        await using var connection = new SqlConnection(Connection);
        var command = new SqlCommand(SqlScriptsProducts.AddProduct, connection);

        command.Parameters.AddWithValue("@ProductNameId", product.ProductName.ProductNameId);
        command.Parameters.AddWithValue("@fullName", product.FullName);

        await DoQuery(connection, command);
    }

    /// <summary>
    /// Получение данных о продукте.
    /// </summary>
    /// <returns>Массив данных о продукте.</returns>
    public async Task<ProductMRItemMap[]> GetProductMrItems()
    {
        var mrItemProducts = new List<ProductMRItemMap>();

        await using (var connection = new SqlConnection(Connection))
        {
            var command = new SqlCommand(SqlScriptsProducts.GetProducts, connection);

            try
            {
                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    mrItemProducts.Add(new ProductMRItemMap
                    {
                        Product = new Product
                        {
                            ProductId = (Guid)reader[0],
                            FullName = (string)reader[1],
                            ProductName = new ProductName
                            {
                                ProductNameId = (Guid)reader[2],
                                Name = (string)reader[3]
                            },
                        },
                        MrItem = new MRItem
                        {
                            MRItemId = (Guid)reader[4]
                        },
                        FoodValue = (decimal)reader[5],
                        ChemicalValue = (decimal)reader[6]
                    });
                }
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        return mrItemProducts.ToArray();
    }

    /// <summary>
    /// Получение объекта "Название продукта".
    /// </summary>
    /// <param name="name">Название продукта.</param>
    /// <returns>Если объект есть, то вернется он, если нет, то пустышка (дефолтные значения).</returns>
    public async Task<ProductName> GetProductName(string name)
    {
        ValidationHelper.CheckString(name);

        var productName = new ProductName();
        await using var connection = new SqlConnection(Connection);
        var command = new SqlCommand(SqlScriptsProducts.GetProductNameForName, connection);

        command.Parameters.AddWithValue("@name", name);

        try
        {
            await connection.OpenAsync();
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                productName.ProductNameId = (Guid)reader[0];
                productName.Name = (string)reader[1];
            }
        }
        catch (SqlException e)
        {
            Debug.WriteLine(e);
            throw;
        }

        return productName;
    }


    /// <summary>
    /// Получение продукта по его названию.
    /// </summary>
    /// <param name="fullName">Название продукта.</param>
    /// <returns>Если продукта имеется в БД, он и вернется, иначе пустой объект.</returns>
    public async Task<Product> GetProductForFullName(string fullName)
    {
        ValidationHelper.CheckString(fullName);

        var product = new Product();
        await using var connection = new SqlConnection(Connection);
        var command = new SqlCommand(SqlScriptsProducts.GetProductForName, connection);

        command.Parameters.AddWithValue("@fullName", fullName);

        try
        {
            await connection.OpenAsync();
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                product.ProductId = (Guid)reader[0];
                product.FullName = (string)reader[1];
                product.ProductName = new ProductName
                {
                    ProductNameId = (Guid)reader[2],
                    Name = (string)reader[3]
                };
            }
        }
        catch (SqlException e)
        {
            Debug.WriteLine(e);
            throw;
        }

        return product;
    }
}