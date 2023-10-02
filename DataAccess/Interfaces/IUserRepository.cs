using Nutritionology;

namespace DataAccess.Interfaces;

/// <summary>
/// Интерфейс для запросов к таблице "Пользователь".
/// Включает запросы для таблиц: Параметр (Parameter), Подписка (Subscription). 
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Добавление параметра.
    /// </summary>
    /// <param name="user">Пользователь, которому добавляется параметр.</param>
    /// <param name="parameter">Параметр.</param>
    /// <returns>Добавленный параметр.</returns>
    Task<Parameter> AddParameter(User user, Parameter parameter);

    /// <summary>
    /// Добавление подписки.
    /// </summary>
    /// <param name="user">Пользователь, которому добавляется подписка.</param>
    /// <param name="subscription">Добавляемая подписка.</param>
    /// <returns>True - в случае успеха, иначе - false.</returns>
    Task<bool> AddSubscription(User user, Subscription subscription);

    /// <summary>
    /// Добавление подписки.
    /// </summary>
    /// <param name="subscription">Добавляемая подписка.</param>
    /// <returns>Все подписки (массив).</returns>
    Task<Subscription[]> AddSubscription(Subscription subscription);
    
    /// <summary>
    /// Получение всех подписок.
    /// </summary>
    /// <returns>Все подписка (массив).</returns>
    Task<Subscription[]> GetSubscriptions();
}