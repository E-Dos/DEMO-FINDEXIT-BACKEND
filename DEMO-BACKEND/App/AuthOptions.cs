using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace App
{
    public class AuthOptions
    {
        public const string ISSUER = "demoFindexIt";
        public const string AUDIENCE = "demofindexit"; 
        const string KEY = "mysupersecret_secretkey!123"; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
