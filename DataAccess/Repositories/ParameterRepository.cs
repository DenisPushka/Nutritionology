using DataAccess.Interfaces;
using Nutritionology;

namespace DataAccess.Repositories;

/// <summary>
/// Репозиторий, реализующий логику для запросов к таблице "Параметр", "Вкусовые предпочтения" и "Проблемные продукты".
/// </summary>
public class ParameterRepository: IParameterRepository
{
    
    /// <summary>
    /// Исполнитель запросов asp net для МР.
    /// </summary>
    private readonly ParameterAspNet _aspParameter;

    public ParameterRepository(ParameterAspNet aspParameter)
    {
        _aspParameter = aspParameter;
    }

    /// <summary>
    /// Добавление параметра.
    /// </summary>
    /// <param name="user">Пользователь.</param>
    /// <param name="parameter">Параметр.</param>
    public async Task AddParameter(User user, Parameter parameter)
    {
        await _aspParameter.AddParameter(user, parameter);
    }

    /// <summary>
    /// Обновление параметра.
    /// </summary>
    /// <param name="user">Пользователь.</param>
    /// <param name="parameter">Обновленный параметр.</param>
    /// <exception cref="NotImplementedException"></exception>
    public async Task UpdateParameter(User user, Parameter parameter)
    {
        throw new NotImplementedException();
    }
}