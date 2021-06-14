using System;
namespace ByteBank
{
  public class SaldoInsuficienteException : OperacaoFinanceiraException
  {
    public decimal Saldo { get; }
    public decimal ValorSaque { get; }
    public SaldoInsuficienteException()
    {
    }
    public SaldoInsuficienteException(decimal saldo, decimal valorSaque)
        : this("Tentativa de saque do valor de " + valorSaque + " em uma conta com saldo de " + saldo)
    {
      Saldo = saldo;
      ValorSaque = valorSaque;
    }
    public SaldoInsuficienteException(string mensagem)
        : base(mensagem)
    {
    }
    public SaldoInsuficienteException(string mensagem, Exception excecaoInterna)
        : base(mensagem, excecaoInterna)
    {
    }
  }
}