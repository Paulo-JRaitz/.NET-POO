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

      Console.WriteLine(@$"
            ---------------- [ Clientes ]----------------");
      for (int i = 0; i < 5; i++)
      {
        //Act
        var c = CriarContaCliente(nomes[i], cpfs[i], saldos[i], i);
        //Assert
        Console.WriteLine(c != null ? "válido" : "invalido");
      }


      UsarSistema();
    }
    public static ContaCorrente CriarContaCliente(string nome, string cpf, decimal saldo, int incremento)
    {
      int ag = 123;
      int numero = 10056 + incremento;
      try
      {
        var contaCorrente = new ContaCorrente(ag, numero)
        {
          Titular = new Cliente
          {
            Nome = nome,
            Cpf = cpf,
            Profissao = $"teste {incremento}"
          },
          Saldo = saldo
        };
        var t = @$"
            Titular:   {contaCorrente.Titular.Nome}
            CPF:       {contaCorrente.Titular.Cpf}
            Profissão: {contaCorrente.Titular.Profissao}
            Agência:   {0,2:X2}{contaCorrente.Agencia}
            Número:    R$ {contaCorrente.Numero}
            Saldo:     R$ {contaCorrente.Saldo}
            
            t. Contas: {ContaCorrente.TotalDeContasCriadas}
            Taxa Op:   {ContaCorrente.TaxaOperacional}
            ";
        Console.WriteLine(t);
        return contaCorrente;
      }
      catch (ArgumentException e)
      {
        System.Console.WriteLine(e.Message);
      }
      catch (OperacaoFinanceiraException e)
      {
        System.Console.WriteLine(e.Message);
      }
      return null;
    }

    public static void UsarSistema()
    {
      var sistema = new SistemaInterno();
      var parceiroComercial = new ParceiroComercial
      {
        Senha = "123456"
      };
      sistema.Logar(parceiroComercial, "123456");

      var funcionarioDiretor = new Diretor("623.086.160-75")
      {
        Nome = "John Doe",
        Profissao = "Diretor de Operações Financeiras",
        Senha = "12345"
      };
      var funcionarioGerente = new GerenteDeConta("768.940.360-39")
      {
        Nome = "Jane Doe",
        Profissao = "Gerente de Contas",
        Senha = "12345"
      };
      sistema.Logar(funcionarioDiretor, "12345");

      sistema.Logar(funcionarioGerente, "12345");
    }
    public void CriarFuncionario()
    {
      var bonus = new GerenciadorBonificacao();

      var funcionario = new Auxiliar("507.749.580-73")
      {
        Nome = "John Smith",
        Profissao = "Zeladora"
      };
      bonus.Registrar(funcionario);
      funcionario.AumentarSalario();

      Console.WriteLine(ContaCorrente.TotalDeContasCriadas);

      Console.WriteLine(@$"
            ---------------- [Funcionarios]----------------
            Nome:       {funcionario.Nome}
            CPF:        {funcionario.Cpf}
            Profissão:  {funcionario.Profissao}
            Salario:    R$ {funcionario.Salario}
            Bonus       R$ {funcionario.GetBonificacao()}

            Funcionários: {Funcionario.TotalDeFuncionarios}

            ---------------- [Bonificação]----------------
            Bonus Anual: {bonus.GetTotalBonificacao()}
            ");
    }
  }
}
