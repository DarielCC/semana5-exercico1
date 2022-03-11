using Semana5.Exercico1.Entidades;
using Semana5.Exercico1.Models;

namespace Semana5.Exercico1.Interfaces
{
    public interface IMovimentacaoContaRepository : IBaseRepository<Conta>
    {
        void AdicionarTransacao(string id, Transacao transacao);
        decimal RetornarSaldoConta(string id, DateOnly data);
        decimal RetornarTotalDespesas(string id, DateOnly data);
        decimal RetornarTotalReceitas(string id, DateOnly data);
        decimal RetornarSaldoInicial(string id);
        IEnumerable<TransacoesPorCategoriaModel> RetornarTransacoesAgrupadasPorCategorias(string numeroConta, DateOnly data);
    }
}
