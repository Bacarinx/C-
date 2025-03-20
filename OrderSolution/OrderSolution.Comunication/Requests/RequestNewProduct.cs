using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSolution.Comunication.Requests
{
    public class RequestNewProduct
    {
        public string Name { get; set; } = String.Empty;
        public int CategoryId { get; set; }
    }
}