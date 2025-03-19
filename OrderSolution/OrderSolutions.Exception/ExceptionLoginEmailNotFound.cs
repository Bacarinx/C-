using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OrderSolutions.Exception.obj
{
    public class ExceptionLoginEmailNotFound : OrderSolutionException
    {
        private readonly List<String> _errors = [];
        public ExceptionLoginEmailNotFound(List<String> errors) : base (String.Empty)
        {
            _errors = errors;
        }

        public override List<string> GetMessage()
        {
            return _errors;
        }

        public override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.BadRequest;
        }
    }
}