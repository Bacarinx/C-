using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poo.Models
{
    public abstract class Conta
    {
        protected decimal Saldo;

        public abstract void Creditar(decimal valor);

        public void ExibirSaldo()
        {
            Console.WriteLine("Seu saldo é de" + Saldo);
        }
    }
}

//protected: Restrito a alterações de suas classes filhas