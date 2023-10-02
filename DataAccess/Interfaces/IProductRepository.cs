using Nutritionology;

namespace DataAccess.Interfaces;

/// <summary>
/// Интерфейс для запросов к таблице "Продукт".
/// Включает запросы для таблиц: название продукта (NameProduct), фото блюда (PhotoDish). 
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Добавление название продукта (НЕ ОБЪЕКТ ПРОДУКТ).
    /// </summary>
    /// <param name="name">Название продукта.</param>
    /// <returns>Возвращает название продуктов (Из таблицы "Название продуктов"!).</returns>
    Task<ProductName> AddNameProduct(string name);

    /// <summary>
    /// Получение всех название продуктов (из таблицы "Названия продуктов"!).
    /// </summary>
    /// <returns>Массив названий продуктов.</returns>
    Task<ProductName[]> GetNameProducts();

    /// <summary>
    /// Добавление продукта.
    /// </summary>
    /// <param name="product">Добавляемый продукт.</param>
    /// <returns>Массив продуктов.</returns>
    Task<Product> AddProduct(Product product);

    /// <summary>
    /// Добавление информации о продукте.
    /// </summary>
    /// <param name="productMrItemMap">Объект со всеми данными.</param>
    /// <returns>Все данные о продукте.</returns>
    Task<ProductMRItemMap[]> AddProductMrItems(ProductMRItemMap[] productMrItemMap);

    /// <summary>
    /// Добавление продуктов.
    /// </summary>
    /// <param name="product">Добавляемые продукты.</param>
    /// <returns>Массив продуктов.</returns>
    Task AddProducts(Product[] product);
}