using System.Text;
using DataAccess.Providers;
using DataAccess.SQLScripts;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Nutritionology;
using Validation;

namespace DataAccess;

/// <summary>
/// Реализатор запросов для таблицы "Параметр" и прилегающих к ней
/// словарей "Вкусовые предпочтения" и "Проблемные продукты".
/// </summary>
public class ParameterAspNet : ParentSql
{
    public ParameterAspNet(IConfiguration config) : base(config)
    {
    }
    
    /// <summary>
    /// Добавление параметра пользовател.
    /// </summary>
    /// <param name="user">Пользвоатель, которому добавляют параметр.</param>
    /// <param name="parameter">Добавляемый параметр.</param>
    public async Task AddParameter(User user, Parameter parameter)
    {
        ValidationHelper.CheckObject(user);
        ValidationHelper.CheckObject(parameter);
        ValidationHelper.CheckObject(parameter.Gender);
        ValidationHelper.CheckGuid(parameter.Gender.GenderId);
        ValidationHelper.CheckNumber(parameter.Age, 0, 110);
        ValidationHelper.CheckNumber(parameter.Height, 40, 240);
        ValidationHelper.CheckNumber(parameter.Weight, 10, 240);
        
        parameter.ParameterId = Guid.NewGuid();

        await using var connection = new SqlConnection(Connection);
        var command = new SqlCommand(SqlScriptsParameter.AddParameter, connection);

        command.Parameters.AddWithValue("@parameterId", parameter.ParameterId);
        command.Parameters.AddWithValue("@genderId", parameter.Gender.GenderId);
        command.Parameters.AddWithValue("@weight", parameter.Weight);
        command.Parameters.AddWithValue("@height", parameter.Height);
        command.Parameters.AddWithValue("@age", parameter.Age);

        await DoQuery(connection, command);
        
        ValidationHelper.CheckGuid(user.Id);
        command = new SqlCommand(SqlScriptsParameter.AddDeferenceParameterUser, connection);
        command.Parameters.AddWithValue("@parameterId", parameter.ParameterId);
        command.Parameters.AddWithValue("@userId", user.Id);

        await DoQuery(connection, command);
    }

    /// <summary>
    /// Добавление любимых и проблемных продуктов.
    /// </summary>
    /// <param name="parameter">Параметр пользователя.</param>
    public async Task AddLikeAndDangerProduct(Parameter parameter)
    {
        ValidationHelper.CheckObject(parameter.LikeProducts);
        ValidationHelper.CheckObject(parameter.ProblemProducts);
        ValidationHelper.CheckGuid(parameter.ParameterId);

        foreach (var likeProduct in parameter.LikeProducts)
        {
            ValidationHelper.CheckObject(likeProduct);
            ValidationHelper.CheckGuid(likeProduct.ProductId);
        }

        foreach (var problemProduct in parameter.ProblemProducts)
        {
            ValidationHelper.CheckObject(problemProduct);
            ValidationHelper.CheckGuid(problemProduct.ProductId);
        }
        
        await using var connection = new SqlConnection(Connection);
        
        await AddProductInParameter(parameter, new StringBuilder(SqlScriptsParameter.AddLikeProducts), parameter.LikeProducts);
        await AddProductInParameter(parameter, new StringBuilder(SqlScriptsParameter.AddProblemProducts), parameter.ProblemProducts);
    }

    /// <summary>
    /// Добавление продуктов (любимых и проблемных).
    /// </summary>
    /// <param name="parameter">Параметр.</param>
    /// <param name="queryAddProducts">Запрос на добавление.</param>
    /// <param name="products">Продукты.</param>
    private async Task AddProductInParameter(Parameter parameter, StringBuilder queryAddProducts, List<Product> products)
    {
        // TODO создание рациона!
        foreach (var product in products)
        {
            queryAddProducts
                .Append("(\'")
                .Append(parameter.ParameterId)
                .Append("\', \'")
                .Append(product.ProductId)
                .Append("\'),");
        }

        queryAddProducts.Remove(queryAddProducts.Length - 1, 1);

        await AddObjectInDb(queryAddProducts.ToString());
    }

    /// <summary>
    /// Изменение параметра.
    /// </summary>
    /// <param name="user">Пользователь.</param>
    /// <param name="parameter">Параметр.</param>
    public async Task UpdateParameter(User user, Parameter parameter)
    {
        throw new NotImplementedException();
        // TODO доделать! 
    }
}