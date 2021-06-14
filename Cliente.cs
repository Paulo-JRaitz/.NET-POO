namespace alura
{
  public class Cliente
  {
    private ulong _cpf;
    public ulong Cpf { get { return _cpf; } set { _cpf = value; } }
    public string Nome { get; set; }
    public string Profissao { get; set; }
  }
}