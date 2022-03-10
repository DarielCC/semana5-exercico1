using Semana5.Exercico1.Enums;
using Semana5.Exercico1.Interfaces;
using Semana5.Exercico1.Models;

namespace Semana5.Exercico1.Entidades
{
    public class Movimentacao : IMovimentacaoWrite, IMovimentacaoRead
    {
        public IList<Conta> Contas { get; set; }

        public Movimentacao() => Contas = new List<Conta>();

        public void AdicionarConta(Conta conta) => Contas.Add(conta);

        public void ApagarConta(string numeroConta) => Contas.Remove(RetornarConta(numeroConta));

        public void AdicionarTransacao(string numeroConta, Transacao transacao)
            => RetornarConta(numeroConta).Transacoes.Add(transacao);

        public decimal RetornarSaldoConta(string numeroConta, DateOnly data)
            => RetornarConta(numeroConta).CalcularSaldo(data);

        public Conta RetornarConta(string numeroConta) =>
                Contas.FirstOrDefault(conta => conta.NumeroConta == numeroConta)
             ?? throw new Exception($"Conta n° {numeroConta} não existe");

        public decimal RetornarTotalDespesas(string numeroConta, DateOnly data)
            => RetornarConta(numeroConta).CalcularTotal(TipoCategoriaEnum.Despesa, data);

        public decimal RetornarTotalReceitas(string numeroConta, DateOnly data)
            => RetornarConta(numeroConta).CalcularTotal(TipoCategoriaEnum.Receita, data);

        public decimal RetornarSaldoInicial(string numeroConta)
            => RetornarConta(numeroConta).SaldoInicial;

        public IEnumerable<TransacoesPorCategoriaModel> RetornarTransacoesAgrupadasPorCategorias(string numeroConta, DateOnly data)
           => RetornarConta(numeroConta).Transacoes.GroupBy(trans => trans.Categoria)
                .Select(g => new TransacoesPorCategoriaModel() { 
                    Categoria = g.Key,
                    Transacoes = g.ToList()
                });
    }
}
