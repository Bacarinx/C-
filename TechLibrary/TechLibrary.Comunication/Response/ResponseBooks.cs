using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Comunication.Response
{
    public class ResponseBooks
    {
        public int Pagination { get; set; }
        public List<ResponseBook> Books { get; set; } = [];
    }
}
