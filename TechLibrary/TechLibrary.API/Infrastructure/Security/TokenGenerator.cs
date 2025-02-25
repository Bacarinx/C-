using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechLibrary.API.Entities;

namespace TechLibrary.API.Infrastructure.Security
{
    public class TokenGenerator
    {
        
        public string Generate(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim("Id", user.Id.ToString())
            };

            var gerador = new JwtKeySecret();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(gerador.Generator(), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
