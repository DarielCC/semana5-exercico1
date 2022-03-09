using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana5.Exercico1.Entidades
{
    public class Movimentacao
    {
        public IList<Conta> Contas { get; private set; }

        public Movimentacao() => Contas = new List<Conta>();

        public void AdicionarConta(Conta conta) => Contas.Add(conta);

        public void AdicionarTransacao(string numeroConta, Transacao transacao) 
            => RetornarConta(numeroConta).Transacoes.Add(transacao);

        public decimal RetornarSaldoConta(string numeroConta, DateOnly data) 
            => RetornarConta(numeroConta).CalcularSaldo(data);

        private Conta RetornarConta(string numeroConta) =>
                Contas.FirstOrDefault(conta => conta.NumeroConta == numeroConta) 
             ?? throw new Exception($"Conta n° {numeroConta} não existe");
    }
}
