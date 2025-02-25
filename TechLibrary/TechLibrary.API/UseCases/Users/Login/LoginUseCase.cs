using TechLibrary.API.Infrastructure.Context;
using TechLibrary.API.Infrastructure.Criptograph;
using TechLibrary.API.Infrastructure.Security;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Response;
using TechLibrary.Exception;

namespace TechLibrary.API.UseCases.Users.Login
{
    public class LoginUseCase
    {
        public ResponseUserRegisteredJson Execute(RequestLoginJson request)
        {
            var context = new TechLibraryDbContext();
            var user = context.Users.FirstOrDefault(user => user.Email.Equals(request.Email));

            if (user == null)
                throw new LoginException();

            var criptograph = new BCryptType();
            var PasswordIsValid = criptograph.Verify(request.Password, user);
            if(!PasswordIsValid)
                throw new LoginException();

            var jwt = new TokenGenerator();
            var token = jwt.Generate(user);

            return new ResponseUserRegisteredJson
            {
                Name = user.Name,
                AccessToken = token
            };
        }
    }
}
