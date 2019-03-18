using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace InfoSystem.Web
{
    /// <summary>
    /// Contains default values for Bearer authentification.
    /// </summary>
    public static class AuthentificationOptions
    {
        /// <summary>
        /// Token provider.
        /// </summary>
        public const string Issuer = "InfoSystemAuthServer";
        /// <summary>
        /// Token user.
        /// </summary>
        public const string Audience = "http://localhost:5000/";
        /// <summary>
        /// Encryption key.
        /// </summary>
        public const string Key = "mysupersecret_secretkey!123";
        /// <summary>
        /// Defines token's lifetime.
        /// </summary>
        public const int Lifetime = 120;
        
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}