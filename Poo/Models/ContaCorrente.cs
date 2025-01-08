using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poo.Models
{
    public class ContaCorrente
    {
        public ContaCorrente (int numeroConta, decimal saldoInicial) {
            NumeroConta = numeroConta;
            _Saldo = saldoInicial;
        }

        public int NumeroConta { get; set; }
        private decimal _Saldo;

        public void Sacar(decimal valor){
            if (_Saldo < valor)
                throw new Exception("Valor para Saque indisponivel");
            _Saldo = _Saldo - valor;
        }

        public void ExibirSaldo() {
            Console.WriteLine($"Saldo: {_Saldo}");
        }
    }
}