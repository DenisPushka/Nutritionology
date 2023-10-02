using LinqToDB;
using Microsoft.Extensions.Configuration;
using Nutritionology;
using Validation;

namespace DataAccess.Providers;

/// <summary>
/// Провайдер Linq2db к словарям связанным с таблицей "Product", 
/// те (ProductName).
/// </summary>
public class ProductLinq2Db : ParentSql
{
    public ProductLinq2Db(IConfiguration config)
        : base(config)
    {
    }

    /// <summary>
    /// Получение всех название продуктов.
    /// </summary>
    /// <returns>Массив название продуктов.</returns>
    public async Task<ProductName[]> GetAllProductNames()
    {
        await using var db = new DbNutritonology(Connection);

        var names =
        (
            from name in db.ProductNames
            select name
        ).Take(1000);

        return names.ToArray();
    }

    /// <summary>
    /// Получение всех продуктов.
    /// </summary>
    /// <returns>Массив продуктов.</returns>
    public async Task<Product[]> GetAllProducts()
    {
        await using var db = new DbNutritonology(Connection);

        var products =
        (
            from product in db.Products
            select product
        ).Take(1000);

        return products
            .LoadWith(product => product.ProductName)
            .ToArray();
    }

    /// <summary>
    /// Добавление названия продукта.
    /// </summary>
    /// <param name="nameProduct">Название продукта.</param>
    public async Task AddNameProduct(string nameProduct)
    {
        ValidationHelper.CheckString(nameProduct);

        await using var db = new DbNutritonology(Connection);
        await db.ProductNames
            .DataContext
            .InsertAsync(new ProductName
            {
                ProductNameId = Guid.NewGuid(),
                Name = nameProduct
            });
    }


    /// <summary>
    /// Получение продукта по полному имени <paramref name="fullName"/>.
    /// </summary>
    /// <param name="fullName">Полное имя продукта.</param>
    /// <returns>Продукт.</returns>
    public async Task<Product> GetProductForFullName(string fullName)
    {
        await using var db = new DbNutritonology(Connection);

        var products =
        (
            from product in db.Products
            where product.FullName.Equals(fullName)
            select product
        ).Take(1);

        return products
            .LoadWith(product => product.ProductName)
            .ToArray()[0];
    }
}