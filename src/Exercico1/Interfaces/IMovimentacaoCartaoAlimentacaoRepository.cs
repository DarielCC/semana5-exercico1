using Semana5.Exercico1.Entidades;

namespace Semana5.Exercico1.Interfaces
{
    public interface IMovimentacaoCartaoAlimentacaoRepository : IBaseRepository<CartaoAlimentacao>
    {
        public void AdicionarTransacao(string numero, Transacao transacao);

        public decimal RetornarSaldoCartao(string numero, DateOnly data);
    }
}
