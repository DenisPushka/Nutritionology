using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Nutritionology;

namespace API;

/// <summary>
/// Контроллер для взаимодействия с Таблицей "Продукт".
/// </summary>
[ApiController, Route("[controller]")]
public class ProductController : ControllerBase
{
    /// <summary>
    /// Репозиторий таблицы "Продукт".
    /// </summary>
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository) => 
        _productRepository = productRepository;

    /// <summary>
    /// Добавление продукта.
    /// </summary>
    /// <param name="product">Добавляемый продукт.</param>
    /// <returns>Массив продуктов.</returns>
    [HttpPost, Route("AddProduct")]
    public async Task<IActionResult> AddProduct(Product product)
    {
        await _productRepository.AddProduct(product);
        return Ok();
    }

    /// <summary>
    /// Добавление информации о продукте.
    /// </summary>
    /// <param name="productMrItemMap">Информация о продукте.</param>
    /// <returns>Вся информация о продукте.</returns>
    [HttpPost, Route("AddProductMrItems")]
    public async Task<IActionResult> AddProductMrItems(ProductMRItemMap[] productMrItemMap) =>
        Ok(await _productRepository.AddProductMrItems(productMrItemMap));
}