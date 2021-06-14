using System;

namespace ByteBank
{
  public class ContaCorrente
  {
    public int ContadorSaquesNaoPermitidos { get; private set; }
    public int ContadorTransferenciasNaoPermitidas { get; private set; }
    public static double TaxaOperacional;
    public static int TotalDeContasCriadas { get; private set; }
    public Cliente Titular { get; set; }
    public int Numero { get; }
    public int Agencia { get; }
    private decimal _saldo { get; set; }
    public decimal Saldo
    {
      get
      {
        return _saldo;
      }
      set
      {
        if (value < 0)
        {
          return;
        }
        _saldo = value;
      }
    }
    public ContaCorrente(int agencia, int numero)
    {
      if (numero <= 0)
      {
        throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
      }

      if (numero <= 0)
      {
        throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
      }

      Agencia = agencia;
      Numero = numero;

      TotalDeContasCriadas++;
      TaxaOperacional = 30 / TotalDeContasCriadas;
    }

    public void Sacar(decimal valor)
    {
      if (valor < 0)
      {
        throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
      }

      if (_saldo < valor)
      {
        ContadorSaquesNaoPermitidos++;
        throw new SaldoInsuficienteException(Saldo, valor);
      }

      _saldo -= valor;
    }

    public void Depositar(decimal valor)
    {
      _saldo += valor;
    }

    public void Transferir(decimal valor, ContaCorrente contaDestino)
    {
      if (valor < 0)
      {
        throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
      }

      try
      {
        Sacar(valor);
      }
      catch (SaldoInsuficienteException ex)
      {
        ContadorTransferenciasNaoPermitidas++;
        throw new OperacaoFinanceiraException("Operação não realizada.", ex);
      }

      contaDestino.Depositar(valor);
    }
  }
}