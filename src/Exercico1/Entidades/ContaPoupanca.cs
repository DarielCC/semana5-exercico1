using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana5.Exercico1.Entidades
{
    public class ContaPoupanca : Conta
    {
        public decimal Rendimento { get; private set; }

        public ContaPoupanca(string descricao, string numeroConta, decimal saldoInicial, decimal rendimento) 
                      : base(descricao, numeroConta, saldoInicial)
            => Rendimento = rendimento;
    }
}
