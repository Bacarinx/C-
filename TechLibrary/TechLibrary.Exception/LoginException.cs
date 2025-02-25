using System.Net;

namespace TechLibrary.Exception
{
    public class LoginException : TechLibraryException
    {
        public LoginException() : base("Email e/ou Senha inválidos") { }

        public override List<string> GetMessageError() => [Message];
        public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;
    }
}
