using FluentValidation.Results;
using TechLibrary.API.Entities;
using TechLibrary.API.Infrastructure.Context;
using TechLibrary.API.Infrastructure.Criptograph;
using TechLibrary.API.Infrastructure.Security;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Response;
using TechLibrary.Exception;

namespace TechLibrary.API.UseCases.Users.Register
{
    public class RegisterUserUseCases
    {
        public ResponseUserRegisteredJson Execute(RequestUserJson request)
        {
            var context = new TechLibraryDbContext();

            var validator = new RegisterUserUseCaseValidator();
            var result = validator.Validate(request);
            var emailAlreadyExistsDB = context.Users.Any(user => user.Email.Equals(request.Email));
            if (emailAlreadyExistsDB)
            {
                result.Errors.Add(new ValidationFailure("Email", "This E-mail already Exists"));
            }

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnRegisterValidator(errorMessages);
            }

            var crypt = new BCryptType();

            var Entity = new User
            {
                Email = request.Email,
                Name = request.Name,
                Password = crypt.HashPassword(request.Password)
            };

            context.Users.Add(Entity);
            context.SaveChanges();

            var jwt = new TokenGenerator();

            return new ResponseUserRegisteredJson
            {
                Name = Entity.Name,
                AccessToken = jwt.Generate(Entity)
            };
                    
        }
    }
}
