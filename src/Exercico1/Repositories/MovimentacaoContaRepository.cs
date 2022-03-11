using Semana5.Exercico1.Enums;
using Semana5.Exercico1.Interfaces;
using Semana5.Exercico1.Models;
using Semana5.Exercico1.Repositories;

namespace Semana5.Exercico1.Entidades
{
    public class MovimentacaoContaRepository : BaseRepository<Conta>, IMovimentacaoContaRepository
    {
        #region Funcionalidades Conta

        public void AdicionarTransacao(string id, Transacao transacao)
            => RetornarElemento(id).Transacoes.Add(transacao);

        public decimal RetornarTotalDespesas(string id, DateOnly data)
            => RetornarElemento(id).CalcularTotal(TipoCategoriaEnum.Despesa, data);

        public decimal RetornarTotalReceitas(string id, DateOnly data)
            => RetornarElemento(id).CalcularTotal(TipoCategoriaEnum.Receita, data);

        public decimal RetornarSaldoInicial(string id)
            => RetornarElemento(id).SaldoInicial;

        public IEnumerable<TransacoesPorCategoriaModel> RetornarTransacoesAgrupadasPorCategorias(string id, DateOnly data)
           => RetornarElemento(id).Transacoes.GroupBy(trans => trans.Categoria)
                .Select(g => new TransacoesPorCategoriaModel()
                {
                    Categoria = g.Key,
                    Transacoes = g.ToList()
                });

        public decimal RetornarSaldoConta(string id, DateOnly data)
            => RetornarElemento(id).CalcularSaldo(data);

        #endregion
    }
}
