using FluentValidation;
using TechLibrary.Comunication.Requests;

namespace TechLibrary.API.UseCases.Users.Register
{
    public class RegisterUserUseCaseValidator : AbstractValidator<RequestUserJson>
    {
        public RegisterUserUseCaseValidator()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("Nome Obrigatório");
            RuleFor(request => request.Email).EmailAddress().WithMessage("Formato incorreto para E-mail");
            RuleFor(request => request.Password).NotEmpty().WithMessage("Senha Obrigatória");
            When(request => !String.IsNullOrEmpty(request.Password), () =>
            {
                RuleFor(request => request.Password.Length).GreaterThanOrEqualTo(8).WithMessage("A senha precisa conter no mínimo 8 caracteres!");
            });
        }
    }
}
