using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using TechLibrary.API.Entities;
using TechLibrary.API.Infrastructure.Context;

namespace TechLibrary.API.Services.LoggedUser
{
    public class LoggedUserService
    {
        private readonly HttpContext _Context;

        public LoggedUserService(HttpContext context)
        {
            _Context = context;
        }

        public User getUser(TechLibraryDbContext dbContext)
        {
            var jwtToken =  _Context.Request.Headers.Authorization.ToString();
            jwtToken = jwtToken[6..].Trim();

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);
            var stringToken = token.Claims.First(claim => claim.Type == "Id").Value;
            var UserId = Guid.Parse(stringToken);

            return dbContext.Users.First(user => user.Id == UserId);
        }
    }
}
