using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poo.Models
{
    public class Professor : Pessoa
    {
        public Professor(string nome) : base (nome){}

        protected decimal Salario { get; set; }
        public sealed override void Apresentar() {
            Console.WriteLine("Sou um professor");
        }
    }
}