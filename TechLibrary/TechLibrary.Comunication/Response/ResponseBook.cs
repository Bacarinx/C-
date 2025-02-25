using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Comunication.Response
{
    public class ResponseBook
    {
        public Guid BookId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string AuthorName { get; set; } = String.Empty;
    }
}
