using Poo.Models;
using Poo.Interfaces;

// ContaCorrente c1 = new ContaCorrente(1282, 1000);
// c1.Sacar(300);
// c1.Sacar(300);
// c1.ExibirSaldo();

// Aluno a1 = new Aluno();
// a1.Nome = "Henrique";
// a1.Idade = 19;
// a1.Apresentar();
// a1.Nota = 8.6;

// Professor p1 = new Professor();
// p1.Nome = "Henrique";
// p1.Idade = 19;
// p1.Apresentar();

Corrente c = new Corrente();
c.Tarifa = 10; 
c.Creditar(500);
c.ExibirSaldo();

ICalculadora cc = new Calculadora();
cc.Somar(3, 5);

// dictionary:

// virtual: Deixa as classes filhas sobreescrever o metodo
// Protected: Uso restrito às classes filhas
// override: Usado para sobreescrever algum método
// Seald (Classe): Não permite heranças futuras
// Seald (Method): Não permite o uso do override
// abstract (Classe): Classe somente para herança, não permite instanciação
// Abstract (Method): Methodo vazio, que obriga as classes filhas a construir o metodo.
// Interface: Contrato que obriga as classes que implementaram a interface a construir os metodos do contrato.