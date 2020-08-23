using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Invest.PRL.JWT
{
    public class AuthTokenOptions
    {
        public const string ISSUER = "SteamInvestServer"; // издатель токена
        public const string AUDIENCE = "SteamInvestClient"; // потребитель токена
        const string KEY = "28d_12m_1999y_bd";   // ключ для шифрации
        public const int LIFETIME = 10000; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
