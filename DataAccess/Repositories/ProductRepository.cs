using System.Data.Entity.Core;
using DataAccess.Interfaces;
using DataAccess.Providers;
using Nutritionology;

namespace DataAccess.Repositories;

/// <summary>
/// Репозиторий, реализующий логику для запросов к таблице "Продукт".
/// </summary>
public class ProductRepository : IProductRepository
{
    /// <summary>
    /// Исполнитель запросов asp net для МР.
    /// </summary>
    private readonly ProductAspNet _aspNetProduct;

    /// <summary>
    /// Исполнитель запросов linq2db для Продукта.
    /// </summary>
    private readonly ProductLinq2Db _linq2DbProduct;


    public ProductRepository(ProductAspNet aspNetProduct, ProductLinq2Db linq2DbProduct)
    {
        _aspNetProduct = aspNetProduct;
        _linq2DbProduct = linq2DbProduct;
    }

    /// <summary>
    /// Добавление названия продукта.
    /// </summary>
    /// <param name="name">Название продукта.</param>
    /// <returns>Объект "Название продукта".</returns>
    public async Task<ProductName> AddNameProduct(string name)
    {
        var productName = await _aspNetProduct.GetProductName(name);

        if (!productName.ProductNameId.Equals(Guid.Empty))
        {
            return productName;
        }

        await _linq2DbProduct.AddNameProduct(name);
        return await _aspNetProduct.GetProductName(name);
    }

    /// <summary>
    /// Получить название продуктов.
    /// </summary>
    /// <returns>Массив названий.</returns>
    public async Task<ProductName[]> GetNameProducts() => await _linq2DbProduct.GetAllProductNames();

    /// <summary>
    /// Добавление продукта.
    /// </summary>
    /// <param name="product">Добавляемый продукт.</param>
    /// <returns>Продукт.</returns>
    public async Task<Product> AddProduct(Product product)
    {
        product.ProductName = await AddNameProduct(product.ProductName.Name);
        var getProduct = await _aspNetProduct.GetProductForFullName(product.FullName);

        if (!getProduct.ProductId.Equals(Guid.Empty))
        {
            return getProduct;
        }

        await _aspNetProduct.AddProduct(product);

        return await _aspNetProduct.GetProductForFullName(product.FullName);
    }

    /// <summary>
    /// Добавление информации о продукте.
    /// </summary>
    /// <param name="productMrItemMap">Информация о продукте.</param>
    /// <returns>Массив данных о продукте.</returns>
    public async Task<ProductMRItemMap[]> AddProductMrItems(ProductMRItemMap[] productMrItemMap)
    {
        productMrItemMap[0].Product = await AddProduct(productMrItemMap[0].Product);

        await _aspNetProduct.AddProductMrItems(productMrItemMap);

        return await _aspNetProduct.GetProductMrItems();
    }

    public Task AddProducts(Product[] product)
    {
        throw new NotImplementedException();
    }
}