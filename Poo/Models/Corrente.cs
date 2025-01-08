using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poo.Models
{
    public class Corrente : Conta
    {
        public override void Creditar(decimal valor) {
            this.Saldo += valor - Tarifa;
        }

        public decimal Tarifa { private get; set; }
    }
}