using ByteBank.Funcionarios;
using ByteBank.Sistemas;
using System;

namespace ByteBank
{
  class Program
  {
    static void Main()
    {
      // Arrange
      string[] nomes = new string[5] { "Paulo Raitz", "Cirlene Raitz", "Vilmar Raitz", "Vilmar R. Junior", "Katia Raitz" };
      string[] cpfs = new string[5] { "934.086.930-30", "639.297.710-47", "826.074.630-17", "731.749.610-33", "554.209.320-59" };
      decimal[] saldos = new decimal[5] { 50, 100, 120, 200, 12000 };

      var contaCorrente = new ContaCorrente(959, 453781)
      {
        Titular = new Cliente
        {
          Nome = nomes[1],
          Cpf = cpfs[1],
          Profissao = $"teste"
        },
        Saldo = saldos[1]
      };
      var t = @$"
            Titular:   {contaCorrente.Titular.Nome}
            CPF:       {contaCorrente.Titular.Cpf}
            Profissão: {contaCorrente.Titular.Profissao}
            Agência:   {0,2:X2}{contaCorrente.Agencia}
            Número:    {contaCorrente.Numero}
            Saldo:     R$ {contaCorrente.Saldo}
            
            t. Contas: {ContaCorrente.TotalDeContasCriadas}
            Taxa Op:   {ContaCorrente.TaxaOperacional}
            ";
      Console.WriteLine(t);
    }
  }
}