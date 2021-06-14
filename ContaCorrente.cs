namespace alura
{
  public class ContaCorrente
  {

    public static int TotalDeContasCriadas { get; private set; }
    public Cliente Titular { get; set; }
    private int _agencia;
    public int Agencia
    {
      get
      {
        return _agencia;
      }
      set
      {
        if (value <= 0)
        {
          return;
        }
        _agencia = value;
      }
    }
    public int Numero { get; set; }
    private double _saldo;
    public double Saldo
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
      Agencia = agencia;
      Numero = numero;
      TotalDeContasCriadas++;
    }
    public bool Sacar(double valor)
    {
      if (_saldo < valor)
      {
        System.Console.WriteLine($"Saldo atual é de R$ {this._saldo}. insuficiente para saque de R$ {valor}");
        return false;
      }

      _saldo -= valor;
      System.Console.WriteLine($"Saque de R$ {valor} efetuado com sucesso!\nSaldo atual: R$ {this._saldo}");
      return true;
    }
    public void Depositar(double valor)
    {
      this._saldo += valor;
      System.Console.WriteLine($"Depósito de R$ {valor} efetuado com sucesso!");
    }

    public bool Transferir(double valor, ContaCorrente contaDestino)
    {
      if (_saldo < valor)
      {
        System.Console.WriteLine($"Saldo atual é de R$ {this._saldo}. insuficiente para transferencia de R$ {valor}");
        return false;
      }

      _saldo -= valor;
      System.Console.WriteLine($@" 
     ------ Transferência eletrônica ------

        de: [
                {this.Titular.Nome}
                {this.Numero}
            ]
           
      Para: [
                {contaDestino.Titular.Nome}
                {contaDestino.Titular.Cpf}
                {contaDestino.Agencia}
                {contaDestino.Numero}
            ]
      ");
      contaDestino.Depositar(valor);


      return true;

    }
  }
}