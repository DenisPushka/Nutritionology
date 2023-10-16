using System.Diagnostics;
using Nutritionology;

namespace Validation;

/// <summary>
/// Помощник в проверке данных.
/// </summary>
public static class ValidationHelper
{
    /// <summary>
    /// Проверка <paramref name="id"/> на Guid.Empty.
    /// </summary>
    /// <param name="id">Проверяемый id.</param>
    /// <exception cref="ArgumentException"/>
    public static void CheckGuid(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException($"Передан пустой Guid id {id}");
        }
    }

    /// <summary>
    /// Проверка строки на null и на содержимое.
    /// </summary>
    /// <param name="text">Проверяемая строка.</param>
    public static void CheckString(string text)
    {
        if (string.IsNullOrWhiteSpace(text) || string.IsNullOrEmpty(text))
        {
            throw new ArgumentException($"Строка - {text}, пуста!");
        }
    }

    /// <summary>
    /// Проверка необходимых полей у пользователя.
    /// </summary>
    /// <param name="user">Проверяемый пользователь.</param>
    public static void CheckUserForAllField(User user)
    {
        CheckObject(user);
        if (
            // TODO изменить.
            // string.IsNullOrWhiteSpace(user.Name)
            // || string.IsNullOrWhiteSpace(user.LastName)
            string.IsNullOrWhiteSpace(user.PasswordHash)
            || string.IsNullOrWhiteSpace(user.Email))
        {
            throw new ArgumentException($"Некорректно введен аргумент {user}"); // TODO ВЫНЕСТИ В CONST.
        }
    }

    /// <summary>
    /// Проверка роли пользователя.
    /// </summary>
    /// <param name="role">Проверяемая роль пользователь.</param>
    public static void CheckRole(UserRole role)
    {
        try
        {
            CheckObject(role);
            CheckString(role.Name);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw new ArgumentException($"Некорректно введен аргумент в {role}"); // TODO ВЫНЕСТИ В CONST.
        }
    }

    /// <summary>
    /// Проверка объект на null.
    /// </summary>
    /// <param name="obj">Проверяемый обхект.</param>
    public static void CheckObject(object obj)
    {
        if (obj == null)
        {
            throw new NullReferenceException($"Объект является null - {obj}");
        }
    }

    /// <summary>
    /// Проверка числа на нахождение в промежутке.
    /// </summary>
    /// <param name="checkNumber">Проверяемое число.</param>
    /// <param name="start">Начало интервала.</param>
    /// <param name="finish">Конец интервала.</param>
    public static void CheckNumber(int checkNumber, int start, int finish)
    {
        if (checkNumber < start || checkNumber > finish)
        {
            throw new ArgumentException($"Передаваемое число {checkNumber} не попало в интервал [{start}..{finish}].");
        }
    }
}