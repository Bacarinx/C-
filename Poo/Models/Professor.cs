using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poo.Models
{
    public class Professor : Pessoa
    {
        public decimal Salario { get; set; }
        public override void Apresentar() {
            Console.WriteLine("Sou um professor");
        }

    }
}