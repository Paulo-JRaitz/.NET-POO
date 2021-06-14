using System;

namespace alura
{
  class Program
  {
    static void Main(string[] args)
    {
      //Cliente Paulo Raitz
      var pauloRaitz = new Cliente();
      pauloRaitz.Nome = "Paulo Raitz";
      pauloRaitz.Cpf = 05182774355;
      pauloRaitz.Profissao = "Estágiário - backend C#";
      //Conta Corrente do Cliente Paulo Raitz
      var contaCorrentePauloRaitz = new ContaCorrente(123, 12344);
      contaCorrentePauloRaitz.Titular = pauloRaitz;

      //Cliente Vilmar Raitz 
      var vilmarRaitz = new Cliente();
      vilmarRaitz.Nome = "Vilmar José Raitz";
      vilmarRaitz.Cpf = 05182774355;
      vilmarRaitz.Profissao = "Pai mais foda do mundo!";
      //Conta Corrente do Cliente Vilmar Raitz
      var contaCorrentevilmarRaitz = new ContaCorrente(123, 12345);
      contaCorrentevilmarRaitz.Titular = vilmarRaitz;

      //Adicionar primrito saldo a conta corrente do Cliente Vilmar Raitz
      contaCorrentevilmarRaitz.Saldo = 10;
      //Deposito Conta corrente Paulo Raitz
      contaCorrentePauloRaitz.Depositar(400.5);

      //Saque Conta corrente Paulo Raitz
      double valorSaque = 235.4;
      bool saque = contaCorrentePauloRaitz.Sacar(valorSaque);

      //Transferencia Conta corrente Paulo Raitz pata Vilmar Raitz
      double valorTransferencia = 10.50;
      bool transferencia = contaCorrentePauloRaitz.Transferir(valorTransferencia, contaCorrentevilmarRaitz);



      System.Console.WriteLine($@"
      Titular: {contaCorrentePauloRaitz.Titular.Nome}
      CPF: {contaCorrentePauloRaitz.Titular.Cpf}
      Profissão: {contaCorrentePauloRaitz.Titular.Profissao}
      Agência: {contaCorrentePauloRaitz.Agencia}
      Número:  {contaCorrentePauloRaitz.Numero}
      Saldo:   {contaCorrentePauloRaitz.Saldo}
      Saque:   {valorSaque} {saque}
      Valor Transferência: {valorTransferencia}

      Titular: {contaCorrentevilmarRaitz.Titular.Nome}
      CPF: {contaCorrentevilmarRaitz.Titular.Cpf}
      Titular: {contaCorrentevilmarRaitz.Titular.Profissao}
      Agência: {contaCorrentevilmarRaitz.Agencia}
      Número:  {contaCorrentevilmarRaitz.Numero}
      Saldo:   {contaCorrentevilmarRaitz.Saldo}
      Saldo Recebido: {valorTransferencia}
      ");

      System.Console.WriteLine($"Total de contas criadas: {ContaCorrente.TotalDeContasCriadas}");
    }
  }
}
