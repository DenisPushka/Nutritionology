using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace API;

/// <summary>
/// Хешировальщик.
/// </summary>
public static class HashHelper
{
    /// <summary>
    /// Вычисление MD5 хэша.
    /// </summary>
    /// <param name="text">Строка из которой вычисляется хеш.</param>
    /// <returns>Хэш.</returns>
    public static string GetHash(string text)
    {
        // using (MD5.Create())
        // {
        //     var random = new byte[16];
        //     //RNGCryptoServiceProvider is an implementation of a random number generator.
        //     var rng = new RNGCryptoServiceProvider();
        //     rng.GetBytes(random);
        //
        //     return Convert.ToBase64String(KeyDerivation.Pbkdf2(
        //         password: text,
        //         salt: random,
        //         prf: KeyDerivationPrf.HMACSHA256,
        //         iterationCount: 100000, // TODO ВЫНЕСТИ.
        //         numBytesRequested: 256 / 8));
        // }
        MD5 md5 = new MD5CryptoServiceProvider();
        var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(text));
        return hash.Aggregate("", (current, b) => current + b.ToString("x2"));
    }
}