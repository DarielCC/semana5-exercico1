
namespace Semana5.Exercico1.Entidades
{
    public class TransacaoCredito : Transacao
    {
        public int NumeroParcela { get; private set; }

        public TransacaoCredito(string descricao, decimal valor, DateOnly data, Categoria categoria, int numeroParcelas) 
            : base(descricao, valor, data, categoria)
            => NumeroParcela = numeroParcelas;
    }
}
