using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Exception
{
    public class ConflictException : TechLibraryException
    {
        public ConflictException(string message) : base(message) { }
        public override List<string> GetMessageError() => [Message];

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.Conflict;
    }
}
