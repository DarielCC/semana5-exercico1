using Semana5.Exercico1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana5.Exercico1.Interfaces
{
    public interface IMovimentacaoWrite
    {
        void AdicionarConta(Conta conta);
        void AdicionarTransacao(string numeroConta, Transacao transacao);
        void ApagarConta(string numeroConta);
    }
}
