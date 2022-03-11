using Semana5.Exercico1.Interfaces;
using Semana5.Exercico1.Repositories;

namespace Semana5.Exercico1.Entidades
{
    public class MovimentacaoCartaoAlimentacaoRepository : BaseRepository<CartaoAlimentacao>, IMovimentacaoCartaoAlimentacaoRepository
    {
        #region Funcionalidades Cartão

        public void AdicionarTransacao(string numero, Transacao transacao)
            => RetornarElemento(numero).Transacoes.Add(transacao);

        public decimal RetornarSaldoCartao(string numero, DateOnly data)
            => RetornarElemento(numero).CalcularSaldo(data);

        #endregion
    }
}
