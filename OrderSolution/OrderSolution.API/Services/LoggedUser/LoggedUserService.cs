using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using OrderSolution.API.Context;
using OrderSolution.API.Entities;

namespace OrderSolution.API.Services.LoggedUser
{
    public class LoggedUserService
    {
        private readonly HttpContext _context;

        public LoggedUserService(HttpContext context)
        {
            _context = context;
        }

        public User getUser(OrderSolutionDbContext dbContext)
        {
            var jwtToken = _context.Request.Headers.Authorization.ToString();
            jwtToken = jwtToken[6..].Trim();

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);
            var stringId = token.Claims.First(claim => claim.Type == "Id").Value;
            var UserID = Convert.ToInt32(stringId);

            return dbContext.Users.First(user => user.Id == UserID);
        }
    }
}