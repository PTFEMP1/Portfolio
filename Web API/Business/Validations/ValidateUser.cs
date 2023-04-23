using Web_API.Models;

namespace Web_API.Business.Validations
{
    public class ValidateUser
    {
        private readonly IConfiguration _config;
        private readonly ILogger<ValidateUser> _logger;
        public ValidateUser(
            IConfiguration config,
            ILogger<ValidateUser> logger)
        {
            _config = config;
            _logger = logger;
        }

        /// <summary>
        /// Verifica se a informação do user é válida.
        /// </summary>
        /// <param name="user">informação do user.</param>
        /// <returns>Retorna true se user for valido.</returns>
        public bool ValidateUserData(User user)
        {
            return UsernameValid(user.username) && PasswordValid(user.password, user.username);
        }

        /// <summary>
        /// Verifica se a username é válido.
        /// </summary>
        /// <param name="username">username do user.</param>
        /// <returns>Retorna true se password for valida.</returns>
        public bool UsernameValid(string username)
        {
            return !Constants.Validations.badWords.Contains(username);
        }

        /// <summary>
        /// Verifica se a password é válida.
        /// </summary>
        /// <param name="password">password do user.</param>
        /// <param name="username">username do user.</param>
        /// <returns>Retorna true se password for valida.</returns>
        public bool PasswordValid(string password, string username)
        {
            return password != username;
        }
    }
}
