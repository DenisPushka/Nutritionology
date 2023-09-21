using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nutritionology;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace API
{
    /// <summary>
    /// Контроллер для авторизации и аутентификации.
    /// </summary>
    [ApiController, Route("[controller]")]
    public class AccountController: ControllerBase
    {
        /// <summary>
        /// Провайдер для таблицы пользователей.
        /// </summary>
        private UserManager<User> UserManager { get; }

        /// <summary>
        /// Провайдер входа в систему.
        /// </summary>
        private SignInManager<User> _signIn { get; }

        /// <summary>
        /// Конструктор с 3 параметрами.
        /// </summary>
        /// <param name="userManager">Провайдер для таблицы пользователей.</param>
        /// <param name="signIn">Провайдер входа в систему.</param>
        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signIn
            )
        {
            UserManager = userManager;
            _signIn = signIn;
        }

        /// <summary>
        /// Регистрация пользователя.
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UserView userView)
        {
            // TODO Validations (user + role + all fields).
            var user = userView.User;

            // TODO ВЫНЕСТИ В СЕРВИС.
            if (ModelState.IsValid)
            {
                user.NormalizedUserName = user.Email!.ToUpper();
                using (MD5.Create())
                {
                    var random = new byte[16];

                    //RNGCryptoServiceProvider is an implementation of a random number generator.
                    var rng = new RNGCryptoServiceProvider();
                    rng.GetBytes(random);

                    user.PasswordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: user.PasswordHash!,
                        salt: random,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 100000, // TODO ВЫНЕСТИ.
                        numBytesRequested: 256 / 8));
                }

                var result = await UserManager.CreateAsync(user, user.PasswordHash);

                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user, userView.Role!.Name!);
                }
            }

            return Ok();
        }
    }
}
