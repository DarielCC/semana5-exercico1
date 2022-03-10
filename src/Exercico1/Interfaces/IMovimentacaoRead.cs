using Semana5.Exercico1.Entidades;
using Semana5.Exercico1.Models;

namespace Semana5.Exercico1.Interfaces
{
    public interface IMovimentacaoRead
    {
        decimal RetornarSaldoConta(string numeroConta, DateOnly data);
        Conta RetornarConta(string numeroConta);
        decimal RetornarTotalDespesas(string numeroConta, DateOnly data);
        decimal RetornarTotalReceitas(string numeroConta, DateOnly data);
        decimal RetornarSaldoInicial(string numeroConta);
        IEnumerable<TransacoesPorCategoriaModel> RetornarTransacoesAgrupadasPorCategorias(string numeroConta, DateOnly data);
    }
}
