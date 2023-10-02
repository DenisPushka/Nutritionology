using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nutritionology;
using Validation;

namespace API
{
    /// <summary>
    /// Контроллер для авторизации и аутентификации.
    /// </summary>
    [ApiController, Route("[controller]")]
    public class AccountController : ControllerBase
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
            if (ModelState.IsValid)
            {
                return await AccountService.CreateUserWithRole(userView.User, userView.Role, UserManager)
                    ? await Login(userView.User)
                    : NoContent();
            }

            return NoContent();
        }


        /// <summary>
        /// Вход пользователя в систему.
        /// </summary>
        /// <param name="user">Данные для входа пользователя в систему.</param>
        /// <returns>При успехе возврашается пользователь со своей ролью, при неуспехе - ничего</returns>
        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                var getUser = await UserManager.FindByEmailAsync(user.Email);
                
                return getUser
                    .PasswordHash
                    .Equals(HashHelper.GetHash(user.PasswordHash))
                    ? Ok(getUser)
                    : NoContent();
            }

            return NoContent();
        }
    }
}