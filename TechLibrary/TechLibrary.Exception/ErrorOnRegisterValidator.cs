using System.Net;

namespace TechLibrary.Exception
{
    public class ErrorOnRegisterValidator : TechLibraryException
    {

        private readonly List<String> _errors;
        public ErrorOnRegisterValidator(List<String> errorMessages) : base(string.Empty)
        {
            _errors = errorMessages;
        }

        public override List<string> GetMessageError() => _errors;
        public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
    }
}
