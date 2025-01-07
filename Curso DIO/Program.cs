using Models;
using System.Text.Json;
using Newtonsoft.Json;

// Venda v1 = new Venda(1, "Teste", 15, DateTime.Now, null);
// Venda v2 = new Venda(2, "Teste2", 30, DateTime.Now, 5);

// List<Venda> vendas = new List<Venda>();
// vendas.Add(v1);
// vendas.Add(v2);
// File.WriteAllText("Arquivos/vendas.json", JsonSerializer.Serialize(vendas)); // Serialize object to JSON

// var conteudo = File.ReadAllText("Arquivos/vendas.json");
// List<Venda> vendas1 = JsonConvert.DeserializeObject<List<Venda>>(conteudo);

// foreach(Venda v in vendas1) {
//   Console.WriteLine(v.Id);
//   Console.WriteLine(v.Produto);
//   Console.WriteLine(v.Preco);
//   Console.WriteLine(v.DataVenda);
//   Console.WriteLine(v.Desconto);
// }

// var anonimous = new { Nome = "Henrique Bacarin", Idade = 19, Altura = 1.84 };
// Console.WriteLine("Nome: " + anonimous.Nome);
// Console.WriteLine("Idade: " + anonimous.Idade);
// Console.WriteLine("Altura: " + anonimous.Altura);

// var content = File.ReadAllText("Arquivos/vendas.json");
// List<Venda> vendas = JsonConvert.DeserializeObject<List<Venda>>(content);

// var anounymousList = vendas.Select(venda => new { venda.Produto, venda.Preco });
// foreach(var v in anounymousList) {
//   Console.WriteLine("Produto: " + v.Produto);
//   Console.WriteLine("Preço: " + v.Preco);
// }

//Vantagem da consulta anonima: Permite exibir somente os dados  que voce precisar. Ex num banco de dados

// dynamic varDinamic = 4;
// varDinamic = "Henrique Bacarin";

// MeuArray<int> meuArray = new MeuArray<int>();
// meuArray.AddArray(0);

// Console.WriteLine(meuArray[0]);

int num = 2;
int num2 = 3;

Console.WriteLine(num.isPair());
Console.WriteLine(num2.isPair());