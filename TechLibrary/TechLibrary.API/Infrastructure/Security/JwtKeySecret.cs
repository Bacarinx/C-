using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TechLibrary.API.Infrastructure.Security
{
    public class JwtKeySecret
    {
        public SymmetricSecurityKey Generator()
        {
            var secretKey = "ASOLhd923oaslkcd08asoaASjmvmXZ210vlZ7ALKSLFD420NBJC";
            var securityKey = Encoding.UTF8.GetBytes(secretKey);
            return new SymmetricSecurityKey(securityKey);
        }
    }
}
