using BCrypt.Net;
using TechLibrary.API.Entities;

namespace TechLibrary.API.Infrastructure.Criptograph
{
    public class BCryptType
    {
        public string HashPassword(string pass) => BCrypt.Net.BCrypt.HashPassword(pass);

        public bool Verify(string password, User user) => BCrypt.Net.BCrypt.Verify(password, user.Password);

    }
}
