using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TEMPLATE_ELDOS_BACKEND.App
{
    public class AuthOptions
    {
        public const string ISSUER = "scpbBars"; // издатель токена
        public const string AUDIENCE = "ScpbBars"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
