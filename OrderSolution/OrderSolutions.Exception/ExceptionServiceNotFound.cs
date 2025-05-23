using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OrderSolutions.Exception
{
    public class ExceptionServiceNotFound : OrderSolutionException
    {
        public ExceptionServiceNotFound() : base("Não há Serviços cadastrados!") { }

        public override List<string> GetMessage() => [Message];

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.NoContent;
    }
}