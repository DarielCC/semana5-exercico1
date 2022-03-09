using Semana5.Exercico1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana5.Exercico1.Interfaces
{
    public interface IMovimentacaoRead
    {
        decimal RetornarSaldoConta(string numeroConta, DateOnly data);
        Conta RetornarConta(string numeroConta);
    }
}
