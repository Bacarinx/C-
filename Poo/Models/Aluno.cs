using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poo.Models
{
    public class Aluno : Pessoa
    {
        public Aluno(string nome) : base(nome){}

        public double Nota { get; set; }
    }
}