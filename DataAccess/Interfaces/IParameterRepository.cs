using Nutritionology;

namespace DataAccess.Interfaces;

/// <summary>
/// Интерфейс для запросов к таблице "Параметр".
/// Включает запросы для таблиц: "Пользователь", "Проблемные продукты" и "Вкусовые предпочтения".
/// </summary>
public interface IParameterRepository
{
    /// <summary>
    /// Добавление параметра пользовател.
    /// </summary>
    /// <param name="user">Пользвоатель, которому добавляют параметр.</param>
    /// <param name="parameter">Добавляемый параметр.</param>
    Task AddParameter(User user, Parameter parameter);

    /// <summary>
    /// Обновление параметра.
    /// </summary>
    /// <param name="user">Пользователь у которого обновляется параметр.</param>
    /// <param name="parameter">Обновляемый параметр.</param>
    Task UpdateParameter(User user, Parameter parameter);
}