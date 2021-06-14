using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public abstract class Funcionario
    {
        public static int TotalDeFuncionarios { get; private set; }
        public string Nome { get; set; }
        public string Cpf { get; private set; }
        public double Salario { get; protected set; }
        public string Profissao { get; set; }
        public Funcionario(double salario, string cpf)
        {
            Cpf = cpf;
            Salario = salario;
            TotalDeFuncionarios++;
        }
        public abstract void AumentarSalario();
        public abstract double GetBonificacao();

    }
}
